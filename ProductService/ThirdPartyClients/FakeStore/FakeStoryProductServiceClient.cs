using Newtonsoft.Json;
using ProductService.DTOs;
using ProductService.Exceptions;
using System.Text;

namespace ProductService.ThirdPartyClients.FakeStore
{
    public class FakeStoryProductServiceClient
    {
        private string requestUrl = "https://fakestoreapi.com/";
        private HttpClient httpClient;
        public FakeStoryProductServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<FakeStoreProductDto> getProductById(long id)
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                FakeStoreProductDto fakeStoreProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);
                if (fakeStoreProduct == null)
                {
                    throw new NotFoundException("Product with id: " + id + " doesn't exist.");
                }
                return fakeStoreProduct;
            }
            return null;
        }

        public async Task<FakeStoreProductDto> createProduct(GenericProductDto product)
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            string jsonContent = JsonConvert.SerializeObject(product);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("products", httpContent);
            string content = await response.Content.ReadAsStringAsync();
            GenericProductDto createdProduct = JsonConvert.DeserializeObject<GenericProductDto>(content);
            return createdProduct;
        }

        public async Task<List<FakeStoreProductDto>> getAllProducts()
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<FakeStoreProductDto> fakeStoreProducts = JsonConvert.DeserializeObject<List<FakeStoreProductDto>>(content);
                return fakeStoreProducts;
            }
            return null;
        }

        public async Task<FakeStoreProductDto> deleteProduct(long id)
        {
            httpClient.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                FakeStoreProductDto deletedProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);

                return deletedProduct;
            }
            return new FakeStoreProductDto();
        }
    }
}
