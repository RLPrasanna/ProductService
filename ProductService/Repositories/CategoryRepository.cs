using ProductService.Models;

namespace ProductService.Repositories
{
    public class CategoryRepository:Repository<Category>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public Category getByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.name == name);
        }
    }
}
