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
            var a = 0;
            var x = 10 / a;
            return await _context.Products
                            .Where(P => !P.IsDeleted)
                            .ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(P => P.Id == id && !P.IsDeleted);
        }
        public async Task<IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice)
        {
            return await _context.Products
                .Where(P => P.Price < maxPrice)
                .ToListAsync();
        }
        public async Task<Product> CreatAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || product.IsDeleted)
                return false;

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}