using ProductService.Models;

namespace ProductService.DTOs
{
    public class FakeStoreGenericProductDto
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public string category { get; set; }
    }
}
