﻿using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository: IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 1);
        Task<IEnumerable<Purchase>> GetAllPurchasesForUser(int userId, int pageSize = 30, int pageIndex = 1);
        Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 1);

        Task<Purchase> GetPurchaseDetails(int userId, int movieId);
    }
}