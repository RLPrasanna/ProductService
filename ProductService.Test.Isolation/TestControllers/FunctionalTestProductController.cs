using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using ProductService.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using ProductService.Services;
using NUnit.Framework;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ProductService;

namespace ProductService.Test.Isolation.TestControllers
{
    //Todo: Implement the complete Test cases
    [TestFixture]
    public class FunctionalTestProductController
    {
        //private WebApplicationFactory<HostingExtension> _factory;
        //private HttpClient _client;
        private Mock<IProductService> _productServiceMock;

        [SetUp]
        public void Setup()
        {
            //_factory = new WebApplicationFactory<Startup>();
            //_client = new HttpClient(_factory);
            _productServiceMock= new Mock<IProductService>();
        }

        [TearDown]
        public void Teardown()
        {
            //_client
        }
    }
}
