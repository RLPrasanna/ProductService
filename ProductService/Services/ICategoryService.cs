using ProductService.Models;

namespace ProductService.Services
{
    public interface ICategoryService
    {
        Category getCategoryById(string id);
    }
}
