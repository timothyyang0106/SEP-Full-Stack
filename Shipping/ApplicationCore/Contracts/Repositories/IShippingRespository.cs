using ApplicationCore.Entities;


namespace ApplicationCore.Contracts.Repositories
{
    public interface IShippingRepository
    {
        Task<Shipping> GetShippingByIdAsync(int id);
        Task<IEnumerable<Shipping>> GetAllShippingsAsync();
        Task AddShippingAsync(Shipping shipping);
        Task UpdateShippingAsync(Shipping shipping);
        Task DeleteShippingAsync(int id);
    }
}
