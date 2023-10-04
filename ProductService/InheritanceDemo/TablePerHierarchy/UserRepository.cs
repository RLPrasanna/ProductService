namespace ProductService.InheritanceDemo.TablePerHierarchy
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.TPHUsers.Add(user);
            _context.SaveChanges();
        }
    }
}
