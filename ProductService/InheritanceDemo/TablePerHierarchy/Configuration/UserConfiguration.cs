using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ProductService.InheritanceDemo.TablePerHierarchy.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tph_user")
                .HasDiscriminator<string>("user_type")
                .HasValue<TA>("ta")
                .HasValue<Mentor>("mentor")
                .HasValue<Student>("student");
        }
    }
}
