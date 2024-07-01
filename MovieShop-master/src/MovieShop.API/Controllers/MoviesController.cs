using ApplicationCore.Contracts.Services;
using ApplicationCore.Helpers;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    ///     Get collection of movies by pagination and search term for movie title
    ///     default page size is 30
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="page"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<PagedResultSet<MovieCardResponseModel>>> GetAllMovies([FromQuery] int pageSize = 30,
        [FromQuery] int page = 1,
        string title = "")
    {
        var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
        if (movies?.Data?.Any() == false)
        {
            return NotFound(new ErrorDetailsResponseModel { Message = "No movies found for search query" });
        }

        return Ok(movies);
    }

    /// <summary>
    ///     Get Movie Details along with cast belonging to the movie, genres for the movie, trailers and rating
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id:int}", Name = "GetMovie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<MovieDetailsResponseModel>> GetMovie(int id)
    {
        var movie = await _movieService.GetMovieAsync(id);
        return Ok(movie);
    }

    /// <summary>
    ///     Get Top 30 Highest rated movies of all-time
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("top-rated")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<List<MovieCardResponseModel>>> GetTopRatedMovies()
    {
        var movies = await _movieService.GetTopRatedMovies();
        if (movies?.Any() == false)
        {
            return NotFound(new ErrorDetailsResponseModel { Message = "No movies were found" });
        }

        return Ok(movies);
    }

    /// <summary>
    ///     Get Top Grossing Movies(revenue) of all-time
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("top-grossing")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MovieCardResponseModel>>> GetTopRevenueMovies()
    {
        var movies = await _movieService.GetHighestGrossingMovies();
        return Ok(movies);
    }

    /// <summary>
    ///     Get Collection of movies belonging to the given genre, with page size of 30
    /// </summary>
    /// <param name="genreId"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("genre/{genreId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
    public async Task<ActionResult<PagedResultSet<MovieCardResponseModel>>> GetMoviesByGenre(int genreId,
        [FromQuery] int pageSize = 30,
        [FromQuery] int pageIndex = 1)
    {
        var movies = await _movieService.GetMoviesByGenre(genreId, pageSize, pageIndex);
        return Ok(movies);
    }

    /// <summary>
    ///     Get Collection of Reviews belonging to the Movie with pagination ordered by recent reviews, default page size of 30
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/reviews")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MovieReviewResponseModel>>> GetMovieReviews(int id)
    {
        var reviews = await _movieService.GetReviewsForMovie(id);
        return Ok(reviews);
    }

    /// <summary>
    /// Admin to create new Movie including genres of that movies
    /// </summary>
    /// <param name="movieCreateRequest"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<MovieDetailsResponseModel>> CreateMovie(
        [FromBody] MovieCreateRequestModel movieCreateRequest)
    {
        var createdMovie = await _movieService.CreateMovie(movieCreateRequest);
        return CreatedAtRoute("GetMovie", new { id = createdMovie.Id }, createdMovie);
    }

    /// <summary>
    /// Admin to update any existing Movie details
    /// </summary>
    /// <param name="movieCreateRequest"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieCreateRequestModel movieCreateRequest)
    {
        var createdMovie = await _movieService.UpdateMovie(movieCreateRequest);
        return Ok(createdMovie);
    }
}