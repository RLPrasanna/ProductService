using Microsoft.EntityFrameworkCore;

namespace ProductService.InheritanceDemo.TablePerHierarchy
{
    public class MentorRepository
    {
        private readonly ApplicationDbContext _context;

        public MentorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Mentor mentor)
        {
            _context.TPHUsers.Add(mentor);
            _context.SaveChanges();
        }
    }
}
