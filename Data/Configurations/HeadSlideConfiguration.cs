using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class HeadSlideConfiguration:IEntityTypeConfiguration<HeadSlideConfiguration>
    {
        public void Configure(EntityTypeBuilder<HeadSlideConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
