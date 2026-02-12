using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Entities;

namespace SkinetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private  StoreContext _storecontext;
       
        public  ProductsController(StoreContext context)
        {
            _storecontext = context;
        }
        
        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =await _storecontext.Products.ToListAsync();
            return Ok(products);   
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _storecontext.Products.FindAsync(id);
        }

    }
}
