using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id);
    }
}