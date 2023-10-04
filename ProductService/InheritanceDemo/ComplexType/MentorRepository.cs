using Microsoft.EntityFrameworkCore;

namespace ProductService.InheritanceDemo.ComplexType
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
            _context.CMentors.Add(mentor);
            _context.SaveChanges();
        }
    }
}
