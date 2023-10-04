using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductService.InheritanceDemo.TablePerHierarchy.Configuration
{
    public class StudentConfiguration:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.psp).HasColumnName("psp");
            builder.Property(e => e.attendance).HasColumnName("attendance");
        }
    }
}
