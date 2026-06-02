
using Backend.Models;

namespace Backend.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetProductAsync(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
