using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers;

/// <summary>
///     All the below API calls must be executed only for Authenticated Users, with JWT Bearer Token
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserService _userService;

    public UserController(IUserService userService, ICurrentUserService currentUserService)
    {
        _userService = userService;
        _currentUserService = currentUserService;
    }

    private int UserId => _currentUserService.UserId;

    /// <summary>
    ///     Get User Details by Id
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<UserProfileResponseModel>> GetUserByIdAsync(int id)
    {
        if (id != _currentUserService.UserId)
            throw new ForbiddenAccessException($"User Id: {id} does not match with auth in use");

        var user = await _userService.GetUserDetails(UserId);
        return Ok(user);
    }

    /// <summary>
    ///     Get collection of movies purchased by the user
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:int}/purchases")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<IEnumerable<MovieCardResponseModel>>> GetUserPurchasedMoviesAsync(int id)
    {
        if (id != UserId)
            throw new UnauthorizedAccessException($"User Id: {id} does not match with auth in use");

        var userMovies = await _userService.GetAllPurchasesForUser(UserId);
        if (!userMovies.Any())
        {
            return NotFound(new ErrorDetailsResponseModel { Message = "No movies found for search query" });
        }

        return Ok(userMovies);
    }

    /// <summary>
    ///     Get Collection of favorite movies for the user
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:int}/favorites")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<MovieCardResponseModel>> GetUserFavoriteMoviesAsync(int id)
    {
        if (id != UserId)
            throw new UnauthorizedAccessException($"User Id: {id} does not match with auth in use");
        var userMovies = await _userService.GetAllFavoritesForUser(id);
        return Ok(userMovies);
    }

    /// <summary>
    ///     Get all the movie Reviews of the authenticated user
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:int}/reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<UserMovieReviewsResponseModel>> GetUserReviewedMoviesAsync(int id)
    {
        if (id != UserId)
            throw new UnauthorizedAccessException($"User Id: {id} does not match with auth in use");
        var userMovies = await _userService.GetAllReviewsByUser(UserId);
        return Ok(userMovies);
    }
}