namespace ProductService.Models
{
    public class Order:BaseModel
    {
        // Many-to-Many relationship with Products
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
