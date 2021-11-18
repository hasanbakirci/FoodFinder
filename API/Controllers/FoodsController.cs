using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Requests.FoodRequests;
using Services.FoodServices;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var foods = await _foodService.Get();
            return Ok(foods);
        }
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id){
            var isExist = await _foodService.FoodIsExist(id);
            if(isExist){
                var food = await _foodService.GetById(id);
                return Ok(food);
            }
            return NotFound("Id Not Found !");
        }
        [HttpGet("SearchCategory/{name}")]
        public async Task<IActionResult> GetByCategoryName(string name){
            var foods = await _foodService.GetByCategoryName(name);
            return Ok(foods);
        }
        [HttpGet("SearchIngredient/{ingredient}")]
        public async Task<IActionResult> GetByIngredients(string ingredient){
            var foods = await _foodService.GetByIngredients(ingredient);
            return Ok(foods);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
           var isExist = await _foodService.FoodIsExist(id);
            if(isExist){
                var result = await _foodService.Delete(id);
                return Ok(result);
            }
            return NotFound("Id Not Found !"); 
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFoodRequest request){
            var isExist = await _foodService.FoodIsExist(request.Id);
            if(!isExist){
                return NotFound("Id Not Found !");
            }
            try
            {
                 UpdateFoodRequestValidator validator = new UpdateFoodRequestValidator();
                 validator.ValidateAndThrow(request);
                 var result = await _foodService.Update(request);
                 return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodRequest request){
            try
            {
                 CreateFoodRequestValidator validator = new CreateFoodRequestValidator();
                 validator.ValidateAndThrow(request);
                 var result = await _foodService.Create(request);
                 return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}