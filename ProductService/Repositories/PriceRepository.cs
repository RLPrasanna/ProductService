using ProductService.Models;

namespace ProductService.Repositories
{
    public class PriceRepository:Repository<Price>
    {
        private readonly ApplicationDbContext _context;

        public PriceRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public Price getByPrice(double? price)
        {
            return _context.Prices.FirstOrDefault(p => p.price == price);
        }
    }
}
