using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [Route("{id}")]
        [HttpGet]
        public Category getById(string id)
        {
            return _categoryService.getCategoryById(id);
        }
    }
}
