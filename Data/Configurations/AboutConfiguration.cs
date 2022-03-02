using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class AboutConfiguration:IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
