using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Requests.CommentRequests;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {

            var comments = await _commentService.Get();
            return ApiResponse(comments);

        }

        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var comment = await _commentService.GetById(id);
            return ApiResponse(comment);

        }

        [HttpGet("SearchFood/{food}")]
        public async Task<IActionResult> GetByFoodName(string food)
        {

            var comments = await _commentService.GetByFoodName(food);
            return ApiResponse(comments);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _commentService.Delete(id);
            return ApiResponse(result);

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCommentRequest request)
        {

            var result = await _commentService.Update(request);
            return ApiResponse(result);
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequest request)
        {

            var result = await _commentService.Create(request);
            return ApiResponse(result);

        }

        [HttpGet("SearchStatus/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllByStatusIsFalse(){
            var result = await _commentService.GetAllByStatusIsFalse();
            return ApiResponse(result);
        }
    }
}