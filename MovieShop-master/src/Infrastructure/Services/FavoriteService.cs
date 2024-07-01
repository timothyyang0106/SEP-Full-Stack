using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Infrastructure.Helpers;

namespace Infrastructure.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IAsyncRepository<Favorite> _favoriteRepository;

    public FavoriteService(IAsyncRepository<Favorite> favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<FavoriteResponseModel> AddFavorite(FavoriteRequestModel favoriteRequest)
    {
        // See if Movie is already Favorite.
        if (await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId))
            throw new ConflictException("Movie already Favorited");

        var favorite = favoriteRequest.ToFavoriteEntity();
        var newFavorite = await _favoriteRepository.AddAsync(favorite);
        return new FavoriteResponseModel { MovieId = newFavorite.MovieId, UserId = newFavorite.MovieId };
    }

    public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
    {
        var dbFavorite =
            await _favoriteRepository.ListAsync(r => r.UserId == favoriteRequest.UserId &&
                                                     r.MovieId == favoriteRequest.MovieId);
        await _favoriteRepository.DeleteAsync(dbFavorite.First());
    }

    public async Task<bool> FavoriteExists(int id, int movieId)
    {
        return await _favoriteRepository.GetExistsAsync(f => f.MovieId == movieId &&
                                                             f.UserId == id);
    }

    public async Task<FavoriteResponseModel> GetFavoriteDetails(int userId, int movieId)
    {
        throw new NotImplementedException();
    }
}