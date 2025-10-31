
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts() => _repository.GetAll();

        public Product? GetProduct(int id) => _repository.GetById(id);

        public void CreateProduct(Product product)
        {
            if (product.Price < 0)
                throw new Exception("Price cannot be negative.");

            _repository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _repository.Delete(id);
        }
    }
}
