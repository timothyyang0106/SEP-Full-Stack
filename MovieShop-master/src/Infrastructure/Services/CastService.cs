using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ResponseModels;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var castDetails = await _castRepository.GetByIdAsync(id);
            if (castDetails == null) throw new NotFoundException("Cast", id);

            var castDetailsModel = new CastDetailsResponseModel
            {
                Id = castDetails.Id, Gender = castDetails.Gender, ProfilePath = castDetails.ProfilePath,
                Name = castDetails.Name, TmdbUrl = castDetails.TmdbUrl,
            
                Movies = castDetails.MoviesOfCast.Select( mc => new MovieCardResponseModel()
                {
                    Id = mc.MovieId, Title = mc.Movie.Title, PosterUrl = mc.Movie.PosterUrl, ReleaseDate = mc.Movie.ReleaseDate.GetValueOrDefault()
                    
                })
            };

         
            return castDetailsModel;
        }
    }
}