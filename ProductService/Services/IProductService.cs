using ProductService.DTOs;

namespace ProductService.Services
{
    public interface IProductService
    {
        Task<GenericProductDto> getProductById(string id);
        Task<GenericProductDto> createProduct(GenericProductDto product);

        Task<List<GenericProductDto>> getAllProducts();
        Task<GenericProductDto> deleteProduct(string id);
        Task<GenericProductDto> updateProduct(string id,GenericProductDto product);
        List<string> getAllCategories();
        List<GenericProductDto> getProductByCategoryName(string categoryName);
    }
}
