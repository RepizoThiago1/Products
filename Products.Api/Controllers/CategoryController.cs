using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Category;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var category = _service.GetCategory(categoryId);

            return Ok(category);
        }

        [HttpGet("GetCategories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var list = _service.GetAllCategories();

            return Ok(list);
        }

        [HttpPost("AddCategory")]
        public ActionResult<Category> AddCategory(CategoryDTO categoryDTO)
        {
            _service.AddCategory(categoryDTO);

            return Ok(categoryDTO);
        }
    }
}
