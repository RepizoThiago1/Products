using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Category;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;

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
        public ActionResult<BaseResponse<Category>> GetCategory(int categoryId)
        {
            var category = _service.GetCategory(categoryId);

            BaseResponse<Category> response = new()
            {
                Message = "Success !",
                Content = category
            };

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Category>>> GetCategories()
        {
            var categories = _service.GetAllCategories();

            BaseResponse<Category> response = new()
            {
                Message = "Success !",
                ContentList = categories
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<BaseResponse<Category>> AddCategory(CategoryDTO request)
        {
            try
            {
                var category = _service.AddCategory(request);

                BaseResponse<Category> response = new()
                {
                    Message = "Success !",
                    Content = category,
                };

                return Ok(response);
            }
            catch (CategoryAlreadyExistsException error)
            {
                return BadRequest(error.Message);
            }
            catch (CategoryReferenceExists error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
