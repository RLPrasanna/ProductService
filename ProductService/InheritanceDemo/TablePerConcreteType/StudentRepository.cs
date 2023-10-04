namespace ProductService.InheritanceDemo.TablePerConcreteType
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.TPCStudents.Add(student);
            _context.SaveChanges();
        }
    }
}
