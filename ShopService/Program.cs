using Microsoft.EntityFrameworkCore;
using ShopService;

var builder = WebApplication.CreateBuilder(args);
var configs = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configs.GetConnectionString("Connection1")));

var app = builder.Build();


// Configure the HTTP request pipeline.



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
