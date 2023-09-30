using System.Collections;
using System.Text;
using ProductService.DTOs;
using Newtonsoft.Json;
using ProductService.Exceptions;
using ProductService.Models;
using ProductService.ThirdPartyClients.FakeStore;

namespace ProductService.Services
{
    public class FakeStoreProductService:IProductService
    {
        private FakeStoryProductServiceClient fakeStoryProductServiceClient;

        public FakeStoreProductService(FakeStoryProductServiceClient fakeStoryProductServiceClient)
        {
            this.fakeStoryProductServiceClient = fakeStoryProductServiceClient;
        }
        private GenericProductDto MapToGenericProductDto(FakeStoreProductDto? fakeStoreProduct)
        {
            return new GenericProductDto()
            {
                id = fakeStoreProduct.id,
                title = fakeStoreProduct.title,
                price = fakeStoreProduct.price,
                description = fakeStoreProduct.description,
                image = fakeStoreProduct.image,
                category = fakeStoreProduct.category
            };
        }

        public async Task<GenericProductDto> getProductById(long id)
        {
            var fakeStoreProduct = await fakeStoryProductServiceClient.getProductById(id);
            var product = MapToGenericProductDto(fakeStoreProduct);
            return product;
        }

        public async Task<GenericProductDto> createProduct(GenericProductDto product)
        {
            return MapToGenericProductDto(await fakeStoryProductServiceClient.createProduct(product));
        }

        public async Task<List<GenericProductDto>> getAllProducts()
        {
            List<GenericProductDto> genericProductDtos = new List<GenericProductDto>();
            var fakeStoreProduct =await fakeStoryProductServiceClient.getAllProducts();
            foreach (FakeStoreProductDto fakeStoreProductDto in fakeStoreProduct)
            {
                genericProductDtos.Add(MapToGenericProductDto(fakeStoreProductDto));
            }
            return genericProductDtos;
        }

        public async Task<GenericProductDto> deleteProduct(long id)
        {
            return MapToGenericProductDto(await fakeStoryProductServiceClient.deleteProduct(id));
        }

    }
}
