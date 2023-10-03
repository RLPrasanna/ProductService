using Microsoft.EntityFrameworkCore;
using ProductService.InheritanceDemo.TablePerHierarchy;
using ProductService.Models;

namespace ProductService
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasKey(c => c.id);

            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>()
                .ToTable("tph_user")
                .HasDiscriminator<string>("user_type")
                .HasValue<TA>("ta")
                .HasValue<Mentor>("mentor")
                .HasValue<Student>("student");

            modelBuilder.Entity<TA>()
                .Property(e => e.averageRating)
                .HasColumnName("average_rating");

            modelBuilder.Entity<Mentor>()
                .Property(e => e.averageRating)
                .HasColumnName("average_rating");

            modelBuilder.Entity<Student>()
                .Property(e => e.psp)
                .HasColumnName("psp");

            modelBuilder.Entity<Student>()
                .Property(e => e.attendance)
                .HasColumnName("attendance");


        }
    }
}
