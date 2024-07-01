using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ResponseModels;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Get collection of all genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
        public async Task<ActionResult<List<GenreResponseModel>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            if (genres?.Any() == false)
            {
                return NotFound(new ErrorDetailsResponseModel { Message = "No Genres Found" });
            }

            return Ok(genres);
        }
    }
}