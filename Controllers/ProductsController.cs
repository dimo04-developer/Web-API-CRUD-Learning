using Application.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(Products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Product = await _productServices.GetByIdAsync(id);
            return Ok(Product);
        }
    }
}