using ApplicationCore.Contracts.Repositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {               
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Include(u => u.RolesOfUser).FirstOrDefaultAsync(u => u.Email == email);
        }
        

        public async Task<IEnumerable<Review>> GetReviewsByUser(int userId)
        {
            var reviews = await _dbContext.Reviews.Include(r=>r.Movie).Where(r => r.UserId == userId).ToListAsync();
            return reviews;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CheckMoviePurchased(int userId, int movieId)
        {
            return await _dbContext.Purchases.AnyAsync(p => p.MovieId == movieId && p.UserId == userId);
        }
    }
}