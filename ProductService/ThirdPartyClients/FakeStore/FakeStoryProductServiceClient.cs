using Newtonsoft.Json;
using ProductService.DTOs;
using ProductService.Exceptions;
using System.Text;
using Microsoft.Extensions;
namespace ProductService.ThirdPartyClients.FakeStore
{
    public class FakeStoryProductServiceClient
    {
        private string fakeStoreApiUrl;
        private string fakeStoreProductsApiPath;

        private string _productRequestsBaseUrl;

        private HttpClient httpClient;
        private IConfiguration _configuration;
        public FakeStoryProductServiceClient(HttpClient httpClient,IConfiguration configuration)
        {
            this.httpClient = httpClient;
            _configuration = configuration;
            fakeStoreApiUrl = _configuration["AppSettings:fakeStoreApiUrl"];
            fakeStoreProductsApiPath = _configuration["AppSettings:fakeStoreApiProductPath"];

            //BaseAddress is not needed anymore as we are passing the full url in the URI section
            //httpClient.BaseAddress = new Uri(fakeStoreApiUrl);
            // Initialize other fieldss
            this._productRequestsBaseUrl = fakeStoreApiUrl + fakeStoreProductsApiPath;
        }
        public async Task<FakeStoreProductDto> getProductById(long id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{_productRequestsBaseUrl}/{id}");
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

        public async Task<FakeStoreProductDto> createProduct(FakeStoreGenericProductDto product)
        {
            
            string jsonContent = JsonConvert.SerializeObject(product);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(_productRequestsBaseUrl, httpContent);
            string content = await response.Content.ReadAsStringAsync();
            FakeStoreProductDto createdProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);
            return createdProduct;
        }

        public async Task<List<FakeStoreProductDto>> getAllProducts()
        {
            HttpResponseMessage response = await httpClient.GetAsync(_productRequestsBaseUrl);
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
            HttpResponseMessage response = await httpClient.DeleteAsync($"{_productRequestsBaseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                FakeStoreProductDto deletedProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);

                return deletedProduct;
            }
            return new FakeStoreProductDto();
        }

        public async Task<FakeStoreProductDto> updateProduct(long id,FakeStoreGenericProductDto product)
        {
            string jsonContent = JsonConvert.SerializeObject(product);
            HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"{_productRequestsBaseUrl}/{id}", httpContent);
            string content = await response.Content.ReadAsStringAsync();
            FakeStoreProductDto updatedProduct = JsonConvert.DeserializeObject<FakeStoreProductDto>(content);
            return updatedProduct;
        }
    }
}
