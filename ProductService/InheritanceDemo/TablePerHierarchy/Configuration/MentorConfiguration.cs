using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductService.InheritanceDemo.TablePerHierarchy.Configuration
{
    public class MentorConfiguration:IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.Property(e => e.averageRating).HasColumnName("averageRating");
        }
    }
}
