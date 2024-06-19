// Infrastructure/Repositories/ShippingRepository.cs
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ShippingDbContext _context;

        public ShippingRepository(ShippingDbContext context)
        {
            _context = context;
        }

        public async Task<Shipping> GetShippingByIdAsync(int id)
        {
            var shipping = await _context.Shippings.FindAsync(id) ?? throw new KeyNotFoundException($"Shipping with id {id} not found.");
            return shipping;
        }

        public async Task<IEnumerable<Shipping>> GetAllShippingsAsync()
        {
            return await _context.Shippings.ToListAsync();
        }

        public async Task AddShippingAsync(Shipping shipping)
        {
            await _context.Shippings.AddAsync(shipping);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShippingAsync(Shipping shipping)
        {
            _context.Shippings.Update(shipping);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShippingAsync(int id)
        {
            var shipping = await _context.Shippings.FindAsync(id);
            if (shipping != null)
            {
                _context.Shippings.Remove(shipping);
                await _context.SaveChangesAsync();
            }
        }
    }
}
