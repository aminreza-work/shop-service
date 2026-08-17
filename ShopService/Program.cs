using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopService;
using ShopService.Controllers.Product;
using ShopService.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configs = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configs.GetConnectionString("Connection1")));

builder.Services.AddScoped<IProduct, ProductRepo>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductMapper>();

});






var app = builder.Build();
// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}




if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
