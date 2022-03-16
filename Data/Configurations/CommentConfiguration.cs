using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Subject).IsRequired().HasMaxLength(255);
            builder.Property(p => p.CommentContent).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}