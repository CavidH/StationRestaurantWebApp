using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class GaleryImageConfiguration:IEntityTypeConfiguration<GaleryImage>
    {
        public void Configure(EntityTypeBuilder<GaleryImage> builder)
        {
            builder.Property(p=>p.Image).IsRequired().HasMaxLength(255);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
