using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Helpers;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    private readonly IAsyncRepository<Favorite> _favoriteRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;

    public MovieService(IMovieRepository movieRepository,
        IAsyncRepository<Favorite> favoriteRepository,
        IReviewRepository reviewRepository)
    {
        _movieRepository = movieRepository;
        _favoriteRepository = favoriteRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByPagination(
        int pageSize = 20, int pageIndex = 0, string title = "")
    {
        Expression<Func<Movie, bool>>? filterExpression = null;
        if (!string.IsNullOrEmpty(title)) filterExpression = movie => title != null && movie.Title.Contains(title);

        var pagedMovies = await _movieRepository.GetPagedData(pageIndex, pageSize, mov => mov.OrderBy(m => m.Title),
            filterExpression);
        var movies =
            new PagedResultSet<MovieCardResponseModel>(pagedMovies.Select(m => m.ToMovieCardResponseModel()),
                pagedMovies.PageIndex,
                pageSize, pagedMovies.TotalCount);
        return movies;
    }


    public async Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 30,
        int pageIndex = 1)
    {
        var pagedMovies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageIndex);
        var movieCards = new List<MovieCardResponseModel>();
        movieCards.AddRange(pagedMovies.Data.Select(movie => new MovieCardResponseModel
        {
            Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate.GetValueOrDefault()
        }));

        return new PagedResultSet<MovieCardResponseModel>(movieCards, pageIndex, pageSize, pagedMovies.Count);
    }

    public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null) throw new NotFoundException("Movie", id);
        var favoritesCount = await _favoriteRepository.GetCountAsync(f => f.MovieId == id);
        var movieDetails = new MovieDetailsResponseModel
        {
            Id = movie.Id, Budget = movie.Budget, Overview = movie.Overview, Price = movie.Price,
            PosterUrl = movie.PosterUrl, Revenue = movie.Revenue,
            ReleaseDate = movie.ReleaseDate.GetValueOrDefault(), Rating = movie.Rating, Tagline = movie.Tagline,
            Title = movie.Title, RunTime = movie.RunTime,
            BackdropUrl = movie.BackdropUrl, FavoritesCount = favoritesCount, ImdbUrl = movie.ImdbUrl,
            TmdbUrl = movie.TmdbUrl
        };

        foreach (var movieGenre in movie.GenresOfMovie)
            movieDetails.Genres.Add(new GenreResponseModel
            {
                Id = movieGenre.Genre.Id, Name = movieGenre.Genre.Name
            });

        foreach (var movieCast in movie.CastsOfMovie)
            movieDetails.Casts.Add(new CastResponseModel
            {
                Id = movieCast.Cast.Id, Name = movieCast.Cast.Name, Character = movieCast.Character,
                Gender = movieCast.Cast.Gender, ProfilePath = movieCast.Cast.ProfilePath,
                TmdbUrl = movieCast.Cast.TmdbUrl
            });

        foreach (var trailer in movie.Trailers)
            movieDetails.Trailers.Add(new TrailerResponseModel
            {
                Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl, MovieId = trailer.MovieId
            });
        
        return movieDetails;
    }

    public async Task<IEnumerable<MovieReviewResponseModel>> GetReviewsForMovie(int id, int pageSize = 25,
        int page = 1)
    {
        var reviews = await _movieRepository.GetMovieReviews(id, pageSize, page);
        var reviewsMovieModel = reviews.Select(r => new MovieReviewResponseModel
        {
            MovieId = r.MovieId, Rating = r.Rating, ReviewText = r.ReviewText, UserId = r.UserId,
            Title = r.User.FirstName + " " + r.User.LastName
        });
        return reviewsMovieModel;
    }

    public async Task AddReviewAsync(ReviewRequestModel reviewRequest)
    {
        var review = new Review
        {
            UserId = reviewRequest.UserId,
            MovieId = reviewRequest.MovieId,
            Rating = reviewRequest.Rating,
            ReviewText = reviewRequest.ReviewText
        };

        await _reviewRepository.AddAsync(review);
    }

    public async Task UpdateReviewAsync(ReviewRequestModel reviewRequest)
    {
        var review = await _reviewRepository.GetByIdAsync(reviewRequest.MovieId);
        if (review == null) throw new NotFoundException("Review", reviewRequest.MovieId);

        review.Rating = reviewRequest.Rating;
        review.ReviewText = reviewRequest.ReviewText;

        await _reviewRepository.UpdateAsync(review);
    }

    public async Task DeleteReviewAsync(int reviewId)
    {
        var review = await _reviewRepository.GetByIdAsync(reviewId);
        if (review == null) throw new NotFoundException("Review", reviewId);

        await _reviewRepository.DeleteAsync(review);
    }

    public async Task<int> GetMoviesCount(string title = "")
    {
        if (string.IsNullOrEmpty(title)) return await _movieRepository.GetCountAsync();
        return await _movieRepository.GetCountAsync(m => m.Title.Contains(title));
    }

    public async Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies()
    {
        var movies = await _movieRepository.GetTopRatedMovies();
        var response = movies.Select(m => m.ToMovieCardResponseModel());
        return response;
    }

    public async Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies()
    {
        var movies = await _movieRepository.GetHighestGrossingMovies();
        var response = movies.Select(m => m.ToMovieCardResponseModel());
        return response;
    }

    public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequest)
    {
        // var createdMovie = await _movieRepository.AddAsync(movie);
        //// var movieGenres = new List<MovieGenre>();
        // foreach (var genre in movieCreateRequest.Genres)
        // {
        //     var movieGenre = new MovieGenre {MovieId = createdMovie.Id, GenreId = genre.Id};
        //     await _genresRepository.AddAsync(movieGenre);
        // }
        throw new NotImplementedException();
    }

    public async Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequest)
    {
        //var movie = _mapper.Map<Movie>(movieCreateRequest);

        //var createdMovie = await _movieRepository.UpdateAsync(movie);
        //// var movieGenres = new List<MovieGenre>();
        //foreach (var genre in movieCreateRequest.Genres)
        //{
        //    var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
        //    await _genresRepository.UpdateAsync(movieGenre);
        //}

        //return _mapper.Map<MovieDetailsResponseModel>(createdMovie);
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<MovieCardResponseModel>> SearchMoviesAsync(string query)
    {
        var movies = await _movieRepository.GetMoviesByTitleAsync(query);
        return movies.Select(m => m.ToMovieCardResponseModel());
    }
}