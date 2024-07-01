using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ReportModels;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IReportsRepository _reportsRepository;

        public AdminService(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequest)
        {
            // //if (_currentUserService.UserId != favoriteRequest.UserId)
            // //    throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to purchase");

            // // check whether the user is Admin and can create the movie claim

            // var movie = _mapper.Map<Movie>(movieCreateRequest);

            // var createdMovie = await _movieRepository.AddAsync(movie);
            //// var movieGenres = new List<MovieGenre>();
            // foreach (var genre in movieCreateRequest.Genres)
            // {
            //     var movieGenre = new MovieGenre {MovieId = createdMovie.Id, GenreId = genre.Id};
            //     await _genresRepository.AddAsync(movieGenre);
            // }

            // return _mapper.Map<MovieDetailsResponseModel>(createdMovie);
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


        public async Task<PagedResultSet<MovieCardResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultSet<MoviesReportModel>> GetTopPurchasedMovies(DateTime? fromDate = null,
            DateTime? toDate = null, int pageSize = 30, int pageIndex = 1)
        {
            var movies = await _reportsRepository.GetTopPurchasedMovies(fromDate, toDate, pageSize, pageIndex);

            var moviesReportModels = movies.ToList();
            if ( !moviesReportModels.Any()) return null!;
            var movieReportModel =
                new PagedResultSet<MoviesReportModel>(moviesReportModels, pageIndex, pageSize, moviesReportModels.FirstOrDefault().MaxRows);

            return movieReportModel;

        }

        
    }
}