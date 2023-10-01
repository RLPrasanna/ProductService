namespace ProductService.Models
{
    public class Product:BaseModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public Category category { get; set; }
    }
}
