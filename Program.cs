using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Repositories;
using Middleware;
using Filters;
using Serilog;
using Serilog.Events;


Log.Logger=new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console()
.WriteTo.File(
    path:"Logs/Information/",
    rollingInterval:RollingInterval.Hour,
    restrictedToMinimumLevel:LogEventLevel.Information
).WriteTo.File(
    path:"Logs/Error/",
    rollingInterval:RollingInterval.Hour,
    restrictedToMinimumLevel:LogEventLevel.Error
).CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
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
app.UseMiddleware<ExceptionMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var context=scope.ServiceProvider.GetRequiredService<AppDbcontext>();
    DbInitializer.SeedData(context);
}   
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
