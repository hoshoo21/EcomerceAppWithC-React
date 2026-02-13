using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace SkinetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private  IProductRepositroy _repository;
       
        public  ProductsController(IProductRepositroy repo)
        {
            _repository = repo;
        }
        
        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return Ok(products);   
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repository.GetProductBrands());
        }

        [HttpGet("producttypes")]

        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _repository.GetProductTypes());
        }

    }
}
