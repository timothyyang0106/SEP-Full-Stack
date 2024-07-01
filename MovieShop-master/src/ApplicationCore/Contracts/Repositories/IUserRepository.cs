using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<Review>> GetReviewsByUser(int userId);
        Task<bool> CheckEmailExists(string email);
        Task<bool> CheckMoviePurchased(int userId, int movieId);
    }
}