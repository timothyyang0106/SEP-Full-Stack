using ApplicationCore.Contracts.Services;
using ApplicationCore.Helpers;
using ApplicationCore.Models.ReportModels;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger _logger;

        public AdminController(IAdminService adminService, ILoggerFactory logger)
        {
            _adminService = adminService;
            _logger = logger.CreateLogger("AdminCategory");
        }


        /// <summary>
        /// Report data for admin to see the top purchased movies in the given date range,
        /// if no dates are given get top purchased movies for last 90 days
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet("top-purchased-movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResultSet<MoviesReportModel>>> GetTopPurchases(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] int pageSize = 30, [FromQuery] int pageIndex = 1)
        {
            _logger.LogTrace("inside admin control trace ");
            _logger.LogDebug("inside admin control debug ");
            _logger.LogInformation("inside admin control information ");
            var movies = await _adminService.GetTopPurchasedMovies(fromDate, toDate, pageSize, pageIndex);
            return Ok(movies);
        }
    }
}