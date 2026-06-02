using Backend.Models;

namespace Backend.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Task<Product?> GetByIdAsync(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
