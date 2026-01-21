using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Repositories;
using Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbcontext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("EcommConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var context=scope.ServiceProvider.GetRequiredService<AppDbcontext>();
    DbInitializer.SeedData(context);
}   
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
