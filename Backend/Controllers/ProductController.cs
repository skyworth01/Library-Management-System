using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var product = await _service.GetProductAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.CreateProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            _service.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return Ok();
        }
    }
}
