using Domain.Entities;

namespace Application.Services
{
    public interface IProductService
    {
        
        Task <Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task <IEnumerable<Product>> GetCheapProductsAsync(decimal maxPrice);
    }
}