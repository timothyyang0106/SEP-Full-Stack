using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        ///     Authenticated User can add a movie review
        /// </summary>
        /// <param name="reviewRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReview([FromBody] ReviewRequestModel reviewRequest)
        {
            var review = await _reviewService.AddMovieReview(reviewRequest);
            return CreatedAtRoute("reviews",
                new { controller = "Reviews", movieId = review.MovieId, userId = review.UserId },
                "Review is created");
        }

        /// <summary>
        /// Get a particular review details by UserId and MovieId
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("movies/{movieId:int}/user{userId:int}", Name = "GetReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetReviewDetails(int movieId, int userId)
        {
            var review = await _reviewService.GetReviewDetails(movieId, userId);
            return Ok(review);
        }

        /// <summary>
        ///     Authenticated User can add a movie review
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{reviewId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteReview(ReviewDeleteRequestModel model)
        {
            await _reviewService.DeleteMovieReview(model);
            return NoContent();
        }

        /// <summary>
        ///     Authenticated User can edit/update a movie review
        /// </summary>
        /// <param name="reviewRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateReview([FromBody] ReviewRequestModel reviewRequest)
        {
            await _reviewService.UpdateMovieReview(reviewRequest);
            return Ok();
        }
    }
}