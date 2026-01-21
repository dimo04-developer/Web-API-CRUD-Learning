using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task <IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice);
        Task<Product>CreatAsync(Product product);
        Task UpdateAsync(Product product);
        Task<bool> Delete(int id);
    }
    
}