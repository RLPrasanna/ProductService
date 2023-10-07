using System.Collections;
using System.Text;
using ProductService.DTOs;
using Newtonsoft.Json;
using ProductService.Exceptions;
using ProductService.Models;
using ProductService.ThirdPartyClients.FakeStore;

namespace ProductService.Services
{
    public class FakeStoreProductService: IFakeStoreProductService
    {
        private FakeStoryProductServiceClient fakeStoryProductServiceClient;

        public FakeStoreProductService(FakeStoryProductServiceClient fakeStoryProductServiceClient)
        {
            this.fakeStoryProductServiceClient = fakeStoryProductServiceClient;
        }
        private FakeStoreGenericProductDto MapToFakeStoreGenericProductDto(FakeStoreProductDto? fakeStoreProduct)
        {
            return new FakeStoreGenericProductDto()
            {
                id = fakeStoreProduct.id,
                title = fakeStoreProduct.title,
                price = fakeStoreProduct.price,
                description = fakeStoreProduct.description,
                image = fakeStoreProduct.image,
                category = fakeStoreProduct.category
            };
        }

        public async Task<FakeStoreGenericProductDto> getProductById(long id)
        {
            var fakeStoreProduct = await fakeStoryProductServiceClient.getProductById(id);
            var product = MapToFakeStoreGenericProductDto(fakeStoreProduct);
            return product;
        }

        public async Task<FakeStoreGenericProductDto> createProduct(FakeStoreGenericProductDto product)
        {
            return MapToFakeStoreGenericProductDto(await fakeStoryProductServiceClient.createProduct(product));
        }

        public async Task<List<FakeStoreGenericProductDto>> getAllProducts()
        {
            List<FakeStoreGenericProductDto> FakeStoreGenericProductDtos = new List<FakeStoreGenericProductDto>();
            var fakeStoreProduct =await fakeStoryProductServiceClient.getAllProducts();
            foreach (FakeStoreProductDto fakeStoreProductDto in fakeStoreProduct)
            {
                FakeStoreGenericProductDtos.Add(MapToFakeStoreGenericProductDto(fakeStoreProductDto));
            }
            return FakeStoreGenericProductDtos;
        }

        public async Task<FakeStoreGenericProductDto> deleteProduct(long id)
        {
            return MapToFakeStoreGenericProductDto(await fakeStoryProductServiceClient.deleteProduct(id));
        }

        public async Task<FakeStoreGenericProductDto> updateProduct(long id,FakeStoreGenericProductDto product)
        {
            return MapToFakeStoreGenericProductDto(await fakeStoryProductServiceClient.updateProduct(id,product));
        }
    }
}
