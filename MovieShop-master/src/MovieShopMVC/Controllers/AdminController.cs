using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;

        public AdminController(IUserService userService, IMovieService movieService, IAdminService adminService)
        {
            _userService = userService;
            _movieService = movieService;
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieCreateRequestModel movieCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //   var newMovie = await _adminService.CreateMovie(movieCreateRequest);
            //  return RedirectToAction("Details", "Movies", newMovie.Id);
            return Ok();
        }
    }
}