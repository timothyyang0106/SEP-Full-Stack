using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;
    private readonly ICurrentUserService _currentUserService;
    private int UserId => _currentUserService.UserId;

    public FavoritesController(IFavoriteService favoriteService, ICurrentUserService currentUserService)
    {
        _favoriteService = favoriteService;
        _currentUserService = currentUserService;
    }

    /// <summary>
    ///     Authenticated user can add a movie to Favorites
    /// </summary>
    /// <param name="favoriteRequest"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult> CreateFavorite([FromBody] FavoriteRequestModel favoriteRequest)
    {
        if (favoriteRequest.UserId != UserId)
            throw new ForbiddenAccessException(
                $"User Id: {favoriteRequest.UserId} does not match with auth in use");

        var favorite = await _favoriteService.AddFavorite(favoriteRequest);
        return CreatedAtRoute("GetFavorite",
            new { controller = "Favorites", movieId = favorite.MovieId, userId = favorite.UserId },
            "Favorite is created");
    }

    /// <summary>
    ///     Authenticated user can remove a movie from favorites list
    /// </summary>
    /// <param name="favoriteRequest"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteFavorite([FromBody] FavoriteRequestModel favoriteRequest)
    {
        await _favoriteService.RemoveFavorite(favoriteRequest);
        return NoContent();
    }

    [HttpGet("movies/{movieId:int}/users/{userId:int}", Name = "GetFavorite")]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDetailsResponseModel))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetUserFavoriteDetailsAsync(int movieId, int userId)
    {
        if (userId != UserId)
            throw new ForbiddenAccessException($"User Id: {userId} does not match with auth in use");

        var purchaseDetails = await _favoriteService.GetFavoriteDetails(userId, movieId);
        return Ok(purchaseDetails);
    }

    /*/// <summary>
    ///     Check if the movie has been added to favorite list by authenticated user
    /// </summary>
    /// <param name="movieId"></param>
    /// <returns></returns>
    [HttpGet("check-movie-favorite/{movieId}")]
    public async Task<ActionResult> IsFavoriteExists(int movieId)
    {
        var favoriteExists = await _userService.FavoriteExists(UserId, movieId);
        return Ok(new { isFavorited = favoriteExists });
    }*/
}