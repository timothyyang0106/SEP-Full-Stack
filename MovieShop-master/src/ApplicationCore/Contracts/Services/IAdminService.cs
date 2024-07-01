using ApplicationCore.Helpers;
using ApplicationCore.Models.ReportModels;
using ApplicationCore.Models.RequestModels;
using ApplicationCore.Models.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IAdminService
{
    Task<PagedResultSet<MovieCardResponseModel>> GetAllPurchasesByMovieId(int movieId);

    Task<PagedResultSet<MoviesReportModel>> GetTopPurchasedMovies(DateTime? fromDate = null,
        DateTime? toDate = null, int pageSize = 30, int page = 1);
}