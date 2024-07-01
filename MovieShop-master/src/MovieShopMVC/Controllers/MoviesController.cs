using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public MoviesController(IMovieService movieService, IUserService userService, ICurrentUserService currentUserService)
        {
            _movieService = movieService;
            _userService = userService;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> Genre(int id, int pageSize = 30, int pageNumber = 1)
        {
            var movies = await _movieService.GetMoviesByGenre(id, pageSize, pageNumber);
            return View("PagedIndex", movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            var userId = _currentUserService.UserId;

            // Check if the movie is purchased by the current user
            var isPurchased = await _userService.IsMoviePurchasedByUser(userId, id);
            movie.IsPurchased = isPurchased;

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> SubmitReview(int movieId)
        {
            var movie = await _movieService.GetMovieAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.MovieTitle = movie.Title;

            var reviewModel = new ReviewRequestModel
            {
                MovieId = movieId,
                UserId = _currentUserService.UserId
            };

            return View(reviewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(ReviewRequestModel reviewRequest)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddReviewAsync(reviewRequest);
                return RedirectToAction("Details", new { id = reviewRequest.MovieId });
            }

            var movie = await _movieService.GetMovieAsync(reviewRequest.MovieId);
            ViewBag.MovieTitle = movie.Title;

            return View(reviewRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var movies = await _movieService.SearchMoviesAsync(query);
            return View(movies);
        }
    }
}