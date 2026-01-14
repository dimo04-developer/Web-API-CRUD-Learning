using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbcontext _context;

        public ProductRepository(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync( P=> P.Id==id);
        }
        public async Task <IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice)
        {
            return await _context.Products
                .Where( P=> P.Price<maxPrice)
                .ToListAsync();
        }
    }
}