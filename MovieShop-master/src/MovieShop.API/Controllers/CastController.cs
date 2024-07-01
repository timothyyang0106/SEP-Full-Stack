using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        /// <summary>
        /// Get cast details information, along with movies the cast belongs to.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsResponseModel))]
        public async Task<ActionResult<CastDetailsResponseModel>> GetCastDetails(int id)
        {
            var cast = await _castService.GetCastDetailsWithMovies(id);
            return Ok(cast);
        }
    }
}