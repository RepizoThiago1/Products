using Microsoft.AspNetCore.Mvc;
using Products.Domain.DTO.Category;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.Interfaces.Services;
using Products.Domain.Responses.@base;
using System.Net;

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
            var content = _service.GetCategory(categoryId);

            var response = BaseResponse<Category>.ToResponse(HttpStatusCode.Found, "Category found!", content);

            return response;
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<Category>>> GetCategories()
        {
            var contentList = _service.GetAllCategories();

            var response = BaseResponse<IEnumerable<Category>>.ToResponse(HttpStatusCode.Found, "Categories found!", contentList);

            return response;
        }

        [HttpPost]
        public ActionResult<BaseResponse<Category>> AddCategory(CategoryDTO request)
        {
            try
            {
                var content = _service.AddCategory(request);

                var response = BaseResponse<Category>.ToResponse(HttpStatusCode.Created, "Category created!", content);

                return response;
            }
            catch (CategoryAlreadyExistsException error)
            {
                var response = BaseResponse<Category>.ToResponse(HttpStatusCode.UnprocessableEntity, error.Message);

                return response;
            }
            catch (CategoryReferenceExists error)
            {
                var response = BaseResponse<Category>.ToResponse(HttpStatusCode.UnprocessableEntity, error.Message);

                return response;
            }
        }
    }
}
