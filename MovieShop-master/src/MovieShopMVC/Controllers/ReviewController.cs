using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMovieService _movieService;

        public ReviewController(IUserService userService, ICurrentUserService currentUserService, IMovieService movieService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int movieId)
        {
            var userId = _currentUserService.UserId;
            var review = await _userService.GetReview(userId, movieId);
            if (review != null)
            {
                var reviewRequestModel = new ReviewRequestModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                };
                ViewBag.MovieTitle = (await _movieService.GetMovieAsync(movieId)).Title;
                return View("Edit", reviewRequestModel);
            }

            var newReviewModel = new ReviewRequestModel
            {
                UserId = userId,
                MovieId = movieId
            };
            ViewBag.MovieTitle = (await _movieService.GetMovieAsync(movieId)).Title;
            return View(newReviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewRequestModel reviewRequest)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddOrUpdateReview(reviewRequest);
                return RedirectToAction("Details", "Movies", new { id = reviewRequest.MovieId });
            }
            ViewBag.MovieTitle = (await _movieService.GetMovieAsync(reviewRequest.MovieId)).Title;
            return View(reviewRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int movieId)
        {
            var userId = _currentUserService.UserId;
            var review = await _userService.GetReview(userId, movieId);

            if (review == null)
            {
                return RedirectToAction("Create", new { movieId });
            }

            var model = new ReviewRequestModel
            {
                MovieId = review.MovieId,
                UserId = review.UserId,
                ReviewText = review.ReviewText,
                Rating = review.Rating
            };

            ViewBag.MovieTitle = (await _movieService.GetMovieAsync(movieId)).Title;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddOrUpdateReview(model);
                return RedirectToAction("Details", "Movies", new { id = model.MovieId });
            }

            ViewBag.MovieTitle = (await _movieService.GetMovieAsync(model.MovieId)).Title;
            return View(model);
        }
    }
}
