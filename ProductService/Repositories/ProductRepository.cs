using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var product=_context.Products.SingleOrDefault(p => p.Id ==id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            
        }
    }
}
