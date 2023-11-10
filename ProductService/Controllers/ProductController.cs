using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<List<GenericProductDto>>> GetAllProducts() 
        {
            List<GenericProductDto> productDtos = await productService.getAllProducts();
            if (productDtos.Count == 0)
            {
                return NotFound(productDtos);
            }

            List<GenericProductDto> genericProductDtos = new List<GenericProductDto>(productDtos);
            // You can remove the first item if needed
            genericProductDtos.RemoveAt(0);

            return Ok(genericProductDtos);
            
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<GenericProductDto>> GetProductById(string id)
        {
            try
            {
                //To fetch individual service associated to Interface
                //var productService2 = productService.GetRequiredService<IProductService>();
                GenericProductDto productDto = await productService.getProductById(id);
                if (productDto == null)
                {
                    throw new NotFoundException("Product Doesn't Exist");
                }
                return Ok(productDto);
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
        public async Task<ActionResult<GenericProductDto>> DeleteProductById(string id)
        {
            var product= await productService.deleteProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<GenericProductDto>> CreateProduct([FromBody] GenericProductDto product)
        {
            var createdProduct= await productService.createProduct(product);
            return CreatedAtAction(nameof(GetProductById),new {id=createdProduct.id},createdProduct);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<GenericProductDto>> UpdateProductById(string id, [FromBody] GenericProductDto product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            var updatedProduct = await productService.updateProduct(id,product);

            return Ok(updatedProduct);
        }

        [Route("categories")]
        [HttpGet]
        public List<string> getAllCategories()
        {
            return productService.getAllCategories();
        }

        [Route("category/{categoryName}")]
        [HttpGet]
        public List<GenericProductDto> GetByCategoryName(string categoryName)
        {
            return productService.getProductByCategoryName(categoryName);
        }
    }
}
