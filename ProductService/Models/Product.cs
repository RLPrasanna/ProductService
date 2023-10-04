using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Models
{
    public class Product:BaseModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        // One-to-One relationship with Price
        [ForeignKey("Price")]
        public Guid priceId { get; set; }
        public Price price { get; set; }

        // Many-to-One relationship with Category
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category category { get; set; }
    }
}
