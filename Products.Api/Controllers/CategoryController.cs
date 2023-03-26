using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(Guid id)
        {
            var category = _service.GetCategory(id);

            return Ok(category);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var list = _service.GetAllCategories();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult<Category> AddCategory(Category category)
        {
            _service.AddCategory(category);

            return Ok(category);
        }
    }
}
