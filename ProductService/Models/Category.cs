namespace ProductService.Models
{
    public class Category:BaseModel
    {
        public string name { get; set; }
        
        public List<Product> products { get; set; }
        
    }
}
