using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        //add-migration AppUser -o DAL/Migrations
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public  DbSet<Product> Products { get; set; }
        public  DbSet<ProductCategory> ProductCategories { get; set; }
        public  DbSet<ProductImage> ProductImages { get; set; }
    }
}