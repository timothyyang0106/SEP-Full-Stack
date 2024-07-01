using ApplicationCore.Contracts.Repositories;

namespace Infrastructure.Repositories
{
    public class CastRepository: EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MoviesOfCast)
                                       .ThenInclude(c => c.Movie).FirstOrDefaultAsync();
            return cast;
        }
    }
}