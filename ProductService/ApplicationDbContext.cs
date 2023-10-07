using Microsoft.EntityFrameworkCore;
using ProductService.InheritanceDemo.ComplexType;
using ProductService.Models;

namespace ProductService
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Order> Orders { get; set; }

        #region Inheritance strategies

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

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and mappings here

            // One-to-One relationship between Product and Price
            modelBuilder.Entity<Product>()
                .HasOne(p => p.price)
                .WithOne()
                .HasForeignKey<Product>(p => p.priceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.category)
                .WithMany(c => c.products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One relationship between Product and Order
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderProducts)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<OrderProduct>()
            //    .HasOne(p => p.Product)
            //    .WithMany(op => op.OrderProducts);

            base.OnModelCreating(modelBuilder);

            #region Inheritance strategies

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
            #endregion


        }
    }
}
