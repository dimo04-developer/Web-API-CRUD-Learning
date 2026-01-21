using Domain.Entities;

namespace Application.Services
{
    public interface IProductService
    {
        
        Task <Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task <IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice);
        Task<Product>CreatAsync(Product product);
        Task UpdateAsync(Product product);
        Task<bool> Delete(int id);
    }
}