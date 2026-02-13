using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Infrastructure.Data;
using System.Runtime.InteropServices;


var builder = WebApplication.CreateBuilder(args);





var connectionstirng = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionstirng));


builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepositroy, ProductRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var service = scope.ServiceProvider;
        var dbContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
        await StoreContextSeed.SeedAsync(service);

    }
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
