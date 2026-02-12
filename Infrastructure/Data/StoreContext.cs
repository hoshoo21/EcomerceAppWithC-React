
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { 
            
        }
        public DbSet<Infrastructure.Entities.Product> Products { get; set; }


    }
}
