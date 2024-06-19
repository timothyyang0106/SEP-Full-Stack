using ApplicationCore.Models;


namespace ApplicationCore.Contracts.Services
{
    public interface IShippingService
    {
        Task<ShippingDto> GetShippingDetailsAsync(int id);
        Task<IEnumerable<ShippingDto>> GetAllShippingDetailsAsync();
        Task AddShippingAsync(ShippingDto shippingDto);
        Task UpdateShippingAsync(ShippingDto shippingDto);
        Task DeleteShippingAsync(int id);
    }
}
