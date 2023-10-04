using Microsoft.EntityFrameworkCore;
using ProductService.InheritanceDemo.ComplexType;
using ProductService.Models;

namespace ProductService
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InheritanceDemo.TablePerHierarchy.User> TPHUsers { get; set; }
        public DbSet<InheritanceDemo.TablePerConcreteType.Mentor> TPCMentors { get; set; }
        public DbSet<InheritanceDemo.TablePerConcreteType.Student> TPCStudents { get; set; }
        public DbSet<InheritanceDemo.TablePerConcreteType.TA> TAs { get; set; }

        public DbSet<InheritanceDemo.TablePerType.Student> TPTStudents { get; set; }
        public DbSet<InheritanceDemo.TablePerType.TA> TPTTAs { get; set; }

        public DbSet<InheritanceDemo.TablePerType.User> TPTUsers { get; set; }
        public DbSet<InheritanceDemo.TablePerType.Mentor> TPTMentors { get; set; }
        public DbSet<InheritanceDemo.ComplexType.Student> CStudents { get; set; }
        public DbSet<InheritanceDemo.ComplexType.TA> CTAs { get; set; }
        public DbSet<InheritanceDemo.ComplexType.Mentor> CMentors { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasKey(c => c.id);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new InheritanceDemo.TablePerHierarchy.Configuration.UserConfiguration());
            modelBuilder.ApplyConfiguration(new InheritanceDemo.TablePerHierarchy.Configuration.TAConfiguration());
            modelBuilder.ApplyConfiguration(new InheritanceDemo.TablePerHierarchy.Configuration.MentorConfiguration());
            modelBuilder.ApplyConfiguration(new InheritanceDemo.TablePerHierarchy.Configuration.StudentConfiguration());


            modelBuilder.Entity<InheritanceDemo.ComplexType.TA>(e => e.OwnsOne(
                ta => ta.user, user =>
                {
                    user.Property(u => u.name).HasColumnName("name");
                    user.Property(u => u.email).HasColumnName("email");
                }
            ));

            modelBuilder.Entity<InheritanceDemo.ComplexType.Student>(e => e.OwnsOne(
                student => student.user, user =>
                {
                    user.Property(u => u.name).HasColumnName("name");
                    user.Property(u => u.email).HasColumnName("email");
                }
            ));

            modelBuilder.Entity<InheritanceDemo.ComplexType.Mentor>(e => e.OwnsOne(
                mentor => mentor.user, user =>
                {
                    user.Property(u => u.name).HasColumnName("name");
                    user.Property(u => u.email).HasColumnName("email");
                }
            ));

        }
    }
}
