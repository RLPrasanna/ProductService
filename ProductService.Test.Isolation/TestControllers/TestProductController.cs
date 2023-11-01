using Microsoft.Extensions.Configuration;
using ProductService.ThirdPartyClients.FakeStore;
using System.Configuration;
using Moq;
using ProductService.Services;
using ProductService.Controllers;
using ProductService.Exceptions;
using ProductService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Test.Isolation.TestControllers
{
    internal class TestProductController
    {
        private FakeStoryProductServiceClient _fakeStoryProductServiceClient;
        private IConfiguration _configuration;
        private Mock<IProductService> productServiceMock;
        private ProductController productController;
        private FakeStoreProductService fakeStoreProductService;

        [SetUp]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _fakeStoryProductServiceClient = new FakeStoryProductServiceClient(new HttpClient(), _configuration);
            fakeStoreProductService = new FakeStoreProductService(_fakeStoryProductServiceClient);
            productServiceMock = new Mock<IProductService>();
            productController = new ProductController(productServiceMock.Object);
        }

        [Test]
        public async Task TestGetProduct()
        {
            //Assert.AreEqual(1,2,"testing for read");
            FakeStoreProductDto product = await _fakeStoryProductServiceClient.getProductById(1);
            Assert.NotNull(product);
        }

        [Test]
        public async Task NotFoundWhenProductDoesntExist()
        {
            //Arrange
            productServiceMock.Setup(p => p.getProductById(It.IsAny<string>()))!.ReturnsAsync(null as GenericProductDto);

            var result = await productController.GetProductById("123");
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value, Is.EqualTo("Product Doesn't Exist"));
        }

        [Test]
        public void ThrowsExceptionOnDeleteWhenProductDoesntExist()
        {
            //Arrange
            productServiceMock.Setup(p => p.deleteProduct(It.IsAny<string>())).ThrowsAsync(new NotFoundException("Product not found"));
            
            var ex =Assert.ThrowsAsync<NotFoundException>(async () => await productController.DeleteProductById("123"));
            Assert.That(ex?.Message, Is.EqualTo("Product not found"));
        }

        [Test]
        public async  Task ReturnsSameProductAsServiceWhenProductExists()
        {
            // Arrange
            GenericProductDto genericProductDto = new GenericProductDto();
            productServiceMock.Setup(p => p.getProductById(It.IsAny<string>())).ReturnsAsync(genericProductDto);

            // Act
            var result = await productController.GetProductById("123");

            // Assert
            if (result is ActionResult<GenericProductDto>)
            {
                var value = (result.Result as OkObjectResult).Value;
                Assert.NotNull(value);
                Assert.AreEqual(genericProductDto.price, (value as GenericProductDto).price);
            }
            else
            {
                // Handle unexpected result type (e.g., NotFound or other status codes)
                Assert.Fail("Unexpected result type");
            }

        }

        [Test]
        public async Task ShouldReturnTitleNamanWithProductID1()
        {
            // Arrange
            GenericProductDto genericProductDto = new GenericProductDto { title = "Naman" };
            productServiceMock.Setup(p => p.getProductById("1")).ReturnsAsync(genericProductDto);

            // Act
            var result = await productController.GetProductById("1");

            // Assert

            // Check if the result is an OkObjectResult and extract the data
            if (result is ActionResult<GenericProductDto> actionResult)
            {
                var value = (result.Result as OkObjectResult).Value;
                Assert.NotNull(value);
                Assert.AreEqual("Naman", (value as GenericProductDto).title);
            }
            else
            {
                // Handle unexpected result type (e.g., NotFound or other status codes)
                Assert.Fail("Unexpected result type");
            }

        }
    }
}
