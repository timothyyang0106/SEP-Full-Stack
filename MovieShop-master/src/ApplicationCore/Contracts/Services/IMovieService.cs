using ApplicationCore.Helpers;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByPagination(int pageSize = 30, int page = 1,
            string title = "");

        Task<PagedResultSet<MovieCardResponseModel>>
            GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1);

        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        Task<IEnumerable<MovieReviewResponseModel>> GetReviewsForMovie(int id, int pageSize = 30, int pageIndex = 1);
        Task AddReviewAsync(ReviewRequestModel reviewRequest);
        Task<int> GetMoviesCount(string title = "");
        Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies();
        Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequest);
        Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequest);
        Task<IEnumerable<MovieCardResponseModel>> SearchMoviesAsync(string query);
    }
}