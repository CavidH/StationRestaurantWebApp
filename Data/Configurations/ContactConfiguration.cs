using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Response).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.Message).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(false);
        }
    }
}