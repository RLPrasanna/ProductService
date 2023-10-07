using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository:Repository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override Product Add(Product product)
        {
            var insertedProduct=base.Add(product);
            Save();
            return insertedProduct;
        }

        public void DeleteById(Guid id)
        {
            var product = GetById(id);
            if (product != null)
            {
                product.category=_context.Categories.SingleOrDefault(c => c.Id == product.CategoryId);
                product.price = _context.Prices.SingleOrDefault(p => p.Id == product.priceId);

                Delete(product);
                Save();
            }
            
        }

        public List<Product> FetchByTitle(string title)
        {
            //using FromSqlInterpolated is safer choice than FromSqlRaw as they automatically parameterize the values
            return _context.Products
                .FromSqlInterpolated($"Select * from products p join OrderProduct op on p.id=op.ProductId where Title={title}")
                .ToList();

        }

    }
}
