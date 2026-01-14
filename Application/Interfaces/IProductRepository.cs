using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task <IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice);
    }
    
}