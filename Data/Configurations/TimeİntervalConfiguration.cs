using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class TimeİntervalConfiguration : IEntityTypeConfiguration<Timeİnterval>
    {
        public void Configure(EntityTypeBuilder<Timeİnterval> builder)
        {
            builder.Property(p => p.Time).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}
