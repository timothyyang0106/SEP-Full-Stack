using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IPurchaseService _purchaseService;
        private int UserId => _currentUserService.UserId;

        public PurchasesController(ICurrentUserService currentUserService, IPurchaseService purchaseService)
        {
            _currentUserService = currentUserService;
            _purchaseService = purchaseService;
        }

        /// <summary>
        ///     Authenticated user can purchase the movie
        /// </summary>
        /// <param name="purchaseRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDetailsResponseModel))]
        public async Task<ActionResult<PurchaseCreatedResponseModel>> CreatePurchase(
            [FromBody] PurchaseRequestModel purchaseRequest)
        {
            if (purchaseRequest.UserId != UserId)
                throw new ForbiddenAccessException(
                    $"User Id: {purchaseRequest.UserId} does not match with auth in use");

            var purchase =
                await _purchaseService.PurchaseMovie(purchaseRequest);
            return CreatedAtRoute("GetPurchase",
                new { controller = "purchases", movieId = purchase.MovieId, userId = purchase.UserId },
                "Purchase is created");
        }

        /// <summary>
        ///     Check whether the movie has been purchased by user
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpHead("movies/{movieId:int}/users/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> IsMoviePurchasedAsync(int movieId, int userId)
        {
            var moviePurchased =
                await _purchaseService.IsMoviePurchased(userId, movieId);
            return moviePurchased ? Ok() : NotFound();
        }

        /// <summary>
        ///     Get Details of the movie purchased by the user
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("movies/{movieId:int}/users/{userId:int}", Name = "GetPurchase")]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ErrorDetailsResponseModel))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUserPurchaseDetailsAsync(int movieId, int userId)
        {
            if (userId != UserId)
                throw new ForbiddenAccessException($"User Id: {userId} does not match with auth in use");

            var purchaseDetails = await _purchaseService.GetPurchasesDetails(userId, movieId);
            return Ok(purchaseDetails);
        }
    }
}