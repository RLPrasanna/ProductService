using System.Collections;
using System.Text;
using ProductService.DTOs;
using Newtonsoft.Json;
using ProductService.Exceptions;
using ProductService.Models;

namespace ProductService.Services
{
    public class FakeStoreProductService:IProductService
    {
        private string requestUrl = "https://fakestoreapi.com/";
        private HttpClient httpClient;
        public FakeStoreProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<GenericProductDto> getProductById(long id)
        {
            httpClient.BaseAddress=new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content=await response.Content.ReadAsStringAsync();
                FakeStoreProductDto fakeStoreProduct= JsonConvert.DeserializeObject<FakeStoreProductDto>(content);
                if (fakeStoreProduct == null)
                {
                    throw new NotFoundException("Product with id: " + id + " doesn't exist.");
                }
                var product = MapToGenericProductDto(fakeStoreProduct);
                return product;
            }
            return null;
        }

        private GenericProductDto MapToGenericProductDto(FakeStoreProductDto? fakeStoreProduct)
        {
            return new GenericProductDto()
            {
                id=fakeStoreProduct.id,
                title = fakeStoreProduct.title,
                price = fakeStoreProduct.price,
                description = fakeStoreProduct.description,
                image = fakeStoreProduct.image,
                category = fakeStoreProduct.category
            };
        }

        public async Task<GenericProductDto> createProduct(GenericProductDto product)
        {
            httpClient.BaseAddress=new Uri(requestUrl);
            string jsonContent = JsonConvert.SerializeObject(product);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("products",httpContent);
            string content=await response.Content.ReadAsStringAsync();
            GenericProductDto createdProduct = JsonConvert.DeserializeObject<GenericProductDto>(content);
            return createdProduct;
        }

        public async Task<List<GenericProductDto>> getAllProducts()
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<FakeStoreProductDto> fakeStoreProduct = JsonConvert.DeserializeObject<List<FakeStoreProductDto>>(content);
                List<GenericProductDto> products = new List<GenericProductDto>();
                foreach(FakeStoreProductDto fakeStoreProductDto in fakeStoreProduct)
                {
                    products.Add(MapToGenericProductDto(fakeStoreProductDto));
                }

                return products;
            }

            return null;
        }

        public async Task<GenericProductDto> deleteProduct(long id)
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content=await response.Content.ReadAsStringAsync();
                FakeStoreProductDto deletedProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);

                return MapToGenericProductDto(deletedProduct);
            }
            return new GenericProductDto();
        }

    }
}
