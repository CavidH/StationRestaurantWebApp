using Core.Entities;
using Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        //add-migration AppUser -o DAL/Migrations
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new AboutConfiguration());
            builder.ApplyConfiguration(new GaleryImageConfiguration());
            builder.ApplyConfiguration(new HeadSlideConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
            //builder.ApplyConfiguration(new ProductImageConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<GaleryImage> GaleryImages { get; set; }
        public DbSet<HeadSlide> HeadSlides { get; set; }
        public DbSet<Setting> Settings { get; set; }


        //public DbSet<ProductImage> ProductImages { get; set; }
    }
}