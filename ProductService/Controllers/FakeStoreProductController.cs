using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.DTOs;
using ProductService.Exceptions;
using ProductService.Services;

namespace ProductService.Controllers
{
    [Route("api/v1/fakeStoreProducts")]
    public class FakeStoreProductController : Controller
    {
        private IFakeStoreProductService productService;

        public FakeStoreProductController(IFakeStoreProductService productService)
        {
            this.productService = productService;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<FakeStoreGenericProductDto>>> getAllProducts() 
        {
            var products= await productService.getAllProducts();

            return Ok(products);
        }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<ActionResult<FakeStoreGenericProductDto>> getProductById(long id)
        {
            try
            {
                //To fetch individual service associated to Interface
                //var productService2 = productService.GetRequiredService<IProductService>();
                var product = await productService.getProductById(id);
                return Ok(product);
            }
            catch (NotFoundException ex)
            {
                //This exception handling is also present in Global level using Middle ware, Hence handling it here is not needed.
                var exceptionDto = new ExceptionDto(HttpStatusCode.NotFound, ex.Message);
                return NotFound(exceptionDto);
            }
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<FakeStoreGenericProductDto>> deleteProductById(long id)
        {
            var product= await productService.deleteProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<FakeStoreGenericProductDto>> createProduct([FromBody] FakeStoreGenericProductDto product)
        {
            var createdProduct= await productService.createProduct(product);
            return CreatedAtAction(nameof(getProductById),new {id=createdProduct.id},createdProduct);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<FakeStoreGenericProductDto>> updateProductById(long id, [FromBody] FakeStoreGenericProductDto product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            var updatedProduct = await productService.updateProduct(id,product);

            return Ok(updatedProduct);
        }
    }
}
