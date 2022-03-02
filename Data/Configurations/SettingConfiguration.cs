using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SettingConfiguration:IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(p => p.Key).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Value).IsRequired().HasMaxLength(255);
            builder.Property(p => p.UpdatedAt).IsRequired().HasMaxLength(255);
        }
    }
}
