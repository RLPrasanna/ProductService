using ProductService.Models;

namespace ProductService.Repositories
{
    public class PriceRepository
    {
        private readonly ApplicationDbContext _context;

        public PriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Price price)
        {
            _context.Prices.Add(price);
            _context.SaveChanges();
        }
    }
}
