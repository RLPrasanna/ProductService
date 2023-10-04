using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductService.InheritanceDemo.TablePerHierarchy.Configuration
{
    public class TAConfiguration:IEntityTypeConfiguration<TA>
    {
        public void Configure(EntityTypeBuilder<TA> builder)
        {
            builder.Property(e => e.averageRating).HasColumnName("averageRating");
        }
    }
}
