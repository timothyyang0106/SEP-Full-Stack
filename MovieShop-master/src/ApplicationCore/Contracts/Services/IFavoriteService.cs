using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IFavoriteService
{
    Task<FavoriteResponseModel> AddFavorite(FavoriteRequestModel favoriteRequest);
    Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
    Task<bool> FavoriteExists(int id, int movieId);
    Task<FavoriteResponseModel> GetFavoriteDetails(int userId, int movieId);
}