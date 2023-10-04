using Microsoft.EntityFrameworkCore;

namespace ProductService.InheritanceDemo.TablePerType
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
            _context.TPTMentors.Add(mentor);
            _context.SaveChanges();
        }
    }
}
