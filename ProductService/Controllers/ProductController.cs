using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using ProductService.Exceptions;
using ProductService.Services;

namespace ProductService.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<GenericProductDto>>> getAllProducts() 
        {
            var products= await productService.getAllProducts();

            return Ok(products);
        }

        [Route("{id:long}")]
        [HttpGet]
        public async Task<ActionResult<GenericProductDto>> getProductById(long id)
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
        public async Task<ActionResult<GenericProductDto>> deleteProductById(long id)
        {
            var product= await productService.deleteProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<GenericProductDto>> createProduct([FromBody] GenericProductDto product)
        {
            var createdProduct= await productService.createProduct(product);
            return CreatedAtAction(nameof(getProductById),new {id=createdProduct.id},createdProduct);
        }

        [Route("{id}")]
        [HttpPut]
        public void updateProductById()
        {

        }
    }
}
