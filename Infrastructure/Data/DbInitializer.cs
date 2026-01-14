using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        public static void SeedData(AppDbcontext context)
        {
            if(context.Products.Any())
            return;

            var newProducts =new List<Product>{
                new Product{Name="Dell Laptopn",Description="Very good laptop for gaming",Price=75800.45m},
                new Product{Name="Lenova Laptopn",Description="Very good laptopn for Development",Price=86800.00m},
                new Product{Name="HP Laptopn",Description="Very good laptopn for Designing",Price=65999.75m},
                new Product{Name="Asus Laptopn",Description="Very good laptopn for All purpose",Price=90000.00m}
                
            };
            context.Products.AddRange(newProducts);
            context.SaveChanges();
        }

    }
}