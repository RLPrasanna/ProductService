using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductService:IProductService
    {
        public async Task<GenericProductDto> getProductById(long id)
        {
            return new GenericProductDto();
            //return "Here is product id: " + id;
        }

        public async Task<GenericProductDto> createProduct(GenericProductDto product)
        {
            return null;
        }

        public Task<List<GenericProductDto>> getAllProducts()
        {
            return null;
        }

        public async Task<GenericProductDto> deleteProduct(long id)
        {
            return null;
        }
    }
}
