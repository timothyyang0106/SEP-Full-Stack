using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        Task<UserProfileResponseModel> GetUserDetails(int id);
        Task<bool> CheckEmailExists(string email);
        Task<Uri> UploadUserProfilePicture(UserProfileRequestModel userProfileRequestModel);

        Task<IEnumerable<MovieCardResponseModel>> GetAllFavoritesForUser(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasesForUser(int id);
        Task<UserMovieReviewsResponseModel> GetAllReviewsByUser(int id);
        Task<PurchaseCreatedResponseModel> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchasedByUser(int userId, int movieId);
        Task<ReviewResponseModel> GetReview(int userId, int movieId);
        Task AddOrUpdateReview(ReviewRequestModel reviewRequest);
    }
}