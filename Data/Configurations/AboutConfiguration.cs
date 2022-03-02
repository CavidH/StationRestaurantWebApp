using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Head).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Content).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.UpdatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
