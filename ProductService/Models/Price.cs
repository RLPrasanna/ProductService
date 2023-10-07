namespace ProductService.Models
{
    public class Price:BaseModel
    {
        public string currency{ get; set; }
        public double price { get; set; }
    }
}
