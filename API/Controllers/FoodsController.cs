using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Requests.FoodRequests;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : BaseController
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var foods = await _foodService.Get();
            return ApiResponse(foods);

        }

        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var food = await _foodService.GetById(id);
            return ApiResponse(food);

        }

        [HttpGet("SearchCategory/{name}")]
        public async Task<IActionResult> GetByCategoryName(string name)
        {

            var foods = await _foodService.GetByCategoryName(name);
            return ApiResponse(foods);

        }

        [HttpGet("SearchIngredient/{ingredient}")]
        public async Task<IActionResult> GetByIngredients(string ingredient)
        {

            var foods = await _foodService.GetByIngredients(ingredient);
            return ApiResponse(foods);

        }

        [HttpPost("SearchImage")]
        public async Task<IActionResult> SearchImage(IFormFile file){
            var result = await _foodService.SearchForImage(file);
            return ApiResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _foodService.Delete(id);
            return ApiResponse(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFoodRequest request)
        {

            var result = await _foodService.Update(request);
            return ApiResponse(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodRequest request)
        {

            var result = await _foodService.Create(request);
            return ApiResponse(result);

        }

    }
}