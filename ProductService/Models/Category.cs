namespace ProductService.Models
{
    public class Category:BaseModel
    {
        public string name { get; set; }
        //onetomany
        public List<Product> products { get; set; }
        
    }
}
