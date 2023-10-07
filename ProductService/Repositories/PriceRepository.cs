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

        public Price Add(Price price)
        {
            return _context.Prices.Add(price).Entity;
            //_context.SaveChanges();
        }
    }
}
