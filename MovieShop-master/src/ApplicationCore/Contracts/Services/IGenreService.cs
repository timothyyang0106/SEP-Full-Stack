using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseModel>> GetAllGenres();
    }
}