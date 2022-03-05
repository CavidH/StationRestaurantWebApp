using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Description).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.Image).IsRequired().HasMaxLength(255);

        }
    }
}
