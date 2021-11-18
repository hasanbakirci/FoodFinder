using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Services.CommentServices;
using Services.Dtos.Requests.CommentRequests;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var comments = await _commentService.Get();
            return Ok(comments);
        }
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> GetById(Guid id){
            var isExist = await _commentService.CommentIsExist(id);
            if(isExist){
                var comment = await _commentService.GetById(id);
                return Ok(comment);
            }
            return NotFound("Id Not Found !");
        }
        [HttpGet("SearchFood/{food}")]
        public async Task<IActionResult> GetByFoodName(string food){
            var comments = await _commentService.GetByFoodName(food);
            return Ok(comments);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id){
            var isExist = await _commentService.CommentIsExist(id);
            if(isExist){
                var result = await _commentService.Delete(id);
                return Ok(result);
            }
            return NotFound("Id Not Found !");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentRequest request){
            var isExist = await _commentService.CommentIsExist(request.Id);
            if(!isExist){
                return NotFound("Id Not Found !");
            }
            try
            {
                UpdateCommentRequestValidator validator = new UpdateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentService.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequest request){
            try
            {
                CreateCommentRequestValidator validator = new CreateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentService.Create(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}