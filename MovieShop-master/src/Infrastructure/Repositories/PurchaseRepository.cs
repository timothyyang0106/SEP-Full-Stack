﻿using ApplicationCore.Contracts.Repositories;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        

        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
  

        public async Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 1)
        {
            var purchases = await _dbContext.Purchases.OrderByDescending(p => p.PurchaseDateTime)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesForUser(int userId, int pageSize = 30, int pageIndex = 1)
        {
            var purchases = await _dbContext.Purchases.Include(m=> m.Movie).Where(p=> p.UserId == userId)
                .OrderByDescending(p => p.PurchaseDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30,
            int pageIndex = 1)
        {
            var purchases = await _dbContext.Purchases.Where(p => p.MovieId == movieId).Include(m => m.Movie)
                .Include(m => m.Customer)
                .OrderByDescending(p => p.PurchaseDateTime)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }

        public async Task<Purchase> GetPurchaseDetails(int userId, int movieId)
        {
            var purchaseDetails = await _dbContext.Purchases
                .Where(p => p.MovieId == movieId && p.UserId == userId).Include(p=> p.Movie).FirstOrDefaultAsync();
            return purchaseDetails;
        }
    }
}