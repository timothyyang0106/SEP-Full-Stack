// Infrastructure/Services/ShippingService.cs
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;

        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }

        public async Task<ShippingDto> GetShippingDetailsAsync(int id)
        {
            var shipping = await _shippingRepository.GetShippingByIdAsync(id);
            return _mapper.Map<ShippingDto>(shipping);
        }

        public async Task<IEnumerable<ShippingDto>> GetAllShippingDetailsAsync()
        {
            var shippings = await _shippingRepository.GetAllShippingsAsync();
            return shippings.Select(shipping => _mapper.Map<ShippingDto>(shipping)).ToList();
        }

        public async Task AddShippingAsync(ShippingDto shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            await _shippingRepository.AddShippingAsync(shipping);
        }

        public async Task UpdateShippingAsync(ShippingDto shippingDto)
        {
            var shipping = _mapper.Map<Shipping>(shippingDto);
            await _shippingRepository.UpdateShippingAsync(shipping);
        }

        public async Task DeleteShippingAsync(int id)
        {
            await _shippingRepository.DeleteShippingAsync(id);
        }
    }
}
