using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryServices;
using Services.Dtos.Requests.CategoryRequests;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var categories = await _categoryService.Get();
            return ApiResponse(categories);

        }

        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var category = await _categoryService.GetById(id);
            return ApiResponse(category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _categoryService.Delete(id);
            return ApiResponse(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {

            var result = await _categoryService.Update(request);
            return ApiResponse(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {

            var result = await _categoryService.Create(request);
            return ApiResponse(result);

        }
    }
}