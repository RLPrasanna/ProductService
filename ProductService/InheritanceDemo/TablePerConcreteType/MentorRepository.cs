using Microsoft.EntityFrameworkCore;

namespace ProductService.InheritanceDemo.TablePerConcreteType
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
            _context.TPCMentors.Add(mentor);
            _context.SaveChanges();
        }
    }
}
