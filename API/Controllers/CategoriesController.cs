using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryServices;
using Services.Dtos.Requests.CategoryRequests;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var categories = await _categoryService.Get();
            return Ok(categories);
        }
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id){
            var isExist = await _categoryService.CategoryIsExist(id);
            if(isExist){
                var category = await _categoryService.GetById(id);
                return Ok(category);
            }
            return NotFound("Id Not Fount !");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
            var isExist = await _categoryService.CategoryIsExist(id);
            if(isExist){
                var result = await _categoryService.Delete(id);
                if(result){
                   return Ok(result); 
                }
                return BadRequest(result);
            }
            return NotFound("Id Not Fount !");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request){
            var isExist = await _categoryService.CategoryIsExist(request.Id);
            if (!isExist){
                return NotFound("Id Not Found !");
            }
            try
            {
                UpdateCategoryRequestValidator validator = new UpdateCategoryRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _categoryService.Update(request);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request){
            try
            {
                CreateCategoryRequestValidator validator = new CreateCategoryRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _categoryService.Create(request);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }  
        }
    }
}