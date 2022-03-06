using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.Property(p => p.TableNumber).IsRequired();
            builder.Property(p => p.MaxPersonCount).IsRequired();
            builder.Property(p => p.IsReserved).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
