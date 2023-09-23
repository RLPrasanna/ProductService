using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Services
{
    public interface IProductService
    {
        Task<GenericProductDto> getProductById(long id);
        Task<GenericProductDto> createProduct(GenericProductDto product);

        Task<List<GenericProductDto>> getAllProducts();
        Task<GenericProductDto> deleteProduct(long id);
    }
}
