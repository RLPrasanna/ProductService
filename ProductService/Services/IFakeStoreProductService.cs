using ProductService.DTOs;


namespace ProductService.Services
{
    public interface IFakeStoreProductService
    {
        Task<FakeStoreGenericProductDto> getProductById(long id);
        Task<FakeStoreGenericProductDto> createProduct(FakeStoreGenericProductDto product);

        Task<List<FakeStoreGenericProductDto>> getAllProducts();
        Task<FakeStoreGenericProductDto> deleteProduct(long id);
        Task<FakeStoreGenericProductDto> updateProduct(long id, FakeStoreGenericProductDto product);
    }
}
