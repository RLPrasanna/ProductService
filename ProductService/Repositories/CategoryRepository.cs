using ProductService.Models;

namespace ProductService.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            return _context.Categories.Add(category).Entity;
            //_context.SaveChanges();
        }
    }
}
