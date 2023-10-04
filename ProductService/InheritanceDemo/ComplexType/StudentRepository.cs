namespace ProductService.InheritanceDemo.ComplexType
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
            _context.CStudents.Add(student);
            _context.SaveChanges();
        }
    }
}
