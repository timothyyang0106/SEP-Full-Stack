using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Helpers;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IBlobService _blobService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAsyncRepository<Favorite> _favoriteRepository;
        private readonly IMovieService _movieService;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IAsyncRepository<Review> _reviewRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
            IAsyncRepository<Favorite> favoriteRepository,
            ICurrentUserService currentUserService,
            IMovieService movieService,
            IAsyncRepository<Review> reviewRepository,
            IBlobService blobService,
            IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _favoriteRepository = favoriteRepository;
            _currentUserService = currentUserService;
            _movieService = movieService;
            _reviewRepository = reviewRepository;
            _blobService = blobService;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<UserProfileResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new NotFoundException("User", id);
            return user.ToUserProfileResponseModel();
        }

        public async Task<UserProfileResponseModel> GetUser(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) throw new NotFoundException("User", email);
            return user.ToUserProfileResponseModel();
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _userRepository.CheckEmailExists(email);
        }

        public async Task<Uri> UploadUserProfilePicture(UserProfileRequestModel userProfileRequestModel)
        {
            _blobService.ContainerName = "userimagescontainer";
            var result = await _blobService.UploadFileBlobAsync(userProfileRequestModel.File.OpenReadStream(),
                userProfileRequestModel.File.ContentType, userProfileRequestModel.File.FileName);
            return result;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllFavoritesForUser(int id)
        {
            var favoriteMovies = await _favoriteRepository.ListAllWithIncludesAsync(
                p => p.UserId == _currentUserService.UserId,
                p => p.Movie);
            return favoriteMovies.Select(f => f.ToMovieCardResponseModel());
        }

        public async Task<PurchaseCreatedResponseModel> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            // See if Movie is already purchased.
            if (await IsMoviePurchased(purchaseRequest, userId))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieAsync(purchaseRequest.MovieId);
            var purchase = new Purchase
            {
                MovieId = purchaseRequest.MovieId,
                PurchaseNumber = purchaseRequest.PurchaseNumber,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,
                TotalPrice = movie.Price.GetValueOrDefault(),
                UserId = userId
            };
            var createdPurchase = await _purchaseRepository.AddAsync(purchase);
            return new PurchaseCreatedResponseModel
            {
                MovieId = createdPurchase.MovieId,
                PurchaseNumber = createdPurchase.PurchaseNumber,
                UserId = createdPurchase.UserId,
                PurchaseDateTime = createdPurchase.PurchaseDateTime
            };
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == userId && p.MovieId == purchaseRequest.MovieId);
        }

        // This method is needed for movie details
        public async Task<bool> IsMoviePurchasedByUser(int userId, int movieId)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == userId && p.MovieId == movieId);
        }   

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasesForUser(int id)
        {
            var totalPurchasesCount = await _purchaseRepository.GetCountAsync(purchase => purchase.UserId == id);
            var purchasedMovies = await _purchaseRepository.GetAllPurchasesForUser(id);

            var movies = new PurchaseResponseModel
            {
                UserId = id,
                PurchasedMovies = new List<MovieCardResponseModel>(),
                TotalMoviesPurchased = totalPurchasesCount
            };
            foreach (var purchase in purchasedMovies)
                movies.PurchasedMovies.Add(new MovieCardResponseModel
                {
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title,
                    PosterUrl = purchase.Movie.PosterUrl,
                    ReleaseDate = purchase.Movie.ReleaseDate.GetValueOrDefault()
                });

            return movies.PurchasedMovies;
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchase = await _purchaseRepository.GetPurchaseDetails(userId, movieId);

            if (purchase == null) throw new NotFoundException($"You did not purchase this movie {movieId} ");
            var purchaseDetails = new PurchaseDetailsResponseModel
            {
                UserId = purchase.UserId,
                MovieId = purchase.MovieId,
                PurchaseNumber = purchase.PurchaseNumber,
                PurchaseDateTime = purchase.PurchaseDateTime,
                Title = purchase.Movie.Title,
                PosterUrl = purchase.Movie.PosterUrl,
                ReleaseDate = purchase.Movie.ReleaseDate.GetValueOrDefault(),
                TotalPrice = purchase.TotalPrice
            };
            return purchaseDetails;
        }

        public async Task<bool> CheckMoviePurchased(int userId, int movieId)
        {
            return await _userRepository.CheckMoviePurchased(userId, movieId);
        }

        public async Task<ReviewResponseModel> GetReview(int userId, int movieId)
        {
            var review = await _reviewRepository.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            return review.Select(r => new ReviewResponseModel
            {
                UserId = r.UserId,
                MovieId = r.MovieId,
                ReviewText = r.ReviewText,
                Rating = r.Rating
            }).FirstOrDefault();
        }

        public async Task AddOrUpdateReview(ReviewRequestModel reviewRequest)
        {
            var existingReview = (await _reviewRepository.ListAsync(r => r.UserId == reviewRequest.UserId && r.MovieId == reviewRequest.MovieId)).FirstOrDefault();
            if (existingReview != null)
            {
                existingReview.Rating = reviewRequest.Rating;
                existingReview.ReviewText = reviewRequest.ReviewText;
                await _reviewRepository.UpdateAsync(existingReview);
            }
            else
            {
                var review = reviewRequest.ToReviewEntity();
                await _reviewRepository.AddAsync(review);
            }
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var review = await _reviewRepository.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            await _reviewRepository.DeleteAsync(review.First());
        }

        public async Task<UserMovieReviewsResponseModel> GetAllReviewsByUser(int id)
        {
            var userReviews = await _userRepository.GetReviewsByUser(id);
            if (userReviews?.Any() != true) throw new NotFoundException($"No reviews found for user: {id}");

            var userReviewModel = new UserMovieReviewsResponseModel
            {
                UserId = id,
                MovieReviews = userReviews.Select(ur => new MovieReviewResponseModel
                {
                    UserId = id, MovieId = ur.MovieId, Rating = ur.Rating, ReviewText = ur.ReviewText
                }).ToList()
            };

            return userReviewModel;
        }
    }
}
