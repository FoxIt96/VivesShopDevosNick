using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VivesShopDevosNick.UI.MVC.Core;

namespace VivesShopDevosNick.UI.MVC.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                StoreDbContext context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Friet", Price = 1.5 },
                        new Product { Name = "Frikandel", Price = 1.75 }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}

