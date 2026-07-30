using Microsoft.EntityFrameworkCore;
using ShopService;
using ShopService.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configs = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configs.GetConnectionString("Connection1")));

builder.Services.AddScoped<IProduct, ProductRepo>();

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
