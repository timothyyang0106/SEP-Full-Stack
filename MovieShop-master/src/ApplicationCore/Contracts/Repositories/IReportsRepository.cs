using ApplicationCore.Models.ReportModels;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IReportsRepository
    {
        Task<IEnumerable<MoviesReportModel>> GetTopPurchasedMovies(DateTime? fromDate = null, DateTime? toDate = null,
            int pageSize = 30, int pageIndex = 1);
    }
}