using Application.Services;
using Microsoft.AspNetCore.Mvc;
using DTOs;
using Domain.Entities;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;
        public ProductController(IProductService productServices)
        {
            _productServices = productServices;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _productServices.GetAllAsync();
            var ProductDTOs = Products.Select(p => new ProductReadDto
            {
                Id=p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description

            });
            return Ok(ProductDTOs);
        }

        // GET: api/products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Product = await _productServices.GetByIdAsync(id);
             if (Product == null)
            return NotFound("Product not found");
            return Ok(Product);
        }
        // GET: api/products/priceunder/500.58
        [HttpGet("priceunder/{maxPrice}")]
        public async Task<IActionResult> GetCheapProductsAsync(decimal maxPrice)
        {
            var Product = await _productServices.GetCheapProductsAsync(maxPrice);
            return Ok(Product);
        }
        //POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateAync(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Description = productCreateDto.Description,
                ExpiryDate = productCreateDto.ExpiryDate
            };
            var createdProduct = await _productServices.CreatAsync(product);
            var productReadDto = new ProductReadDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price
            };
            return CreatedAtRoute("GetProductById",
                new { id = productReadDto.Id },
                productReadDto
            );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _productServices.GetByIdAsync(id);
            if (product == null)
                return NoContent();

            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Description = productUpdateDto.Description;
            product.ExpiryDate = productUpdateDto.ExpiryDate;
            await _productServices.UpdateAsync(product);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var IsDeleted = await _productServices.Delete(id);
            if (!IsDeleted)
                return NoContent();            
            return Ok();

        }
    }
}