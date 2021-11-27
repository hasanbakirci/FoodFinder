using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Result;
using Data.Interfaces;
using FluentValidation;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Responses.CommentResponses;
using Services.Extensions;
using Services.Interfaces;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Create(CreateCommentRequest request)
        {
            try
            {
                var comment = request.ConvertToComment(_mapper);
                CreateCommentRequestValidator validator = new CreateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentRepository.Create(comment);
                return new SuccessResponse<Guid>(result);
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Guid>(ResponseStatus.BadRequest, default, ex.Message);
            }
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var isExist = await _commentRepository.IsExist(id);
            if(!isExist){
                return new ErrorResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundComment);
            }
            var result = await _commentRepository.Delete(id);
            if(result){
                return new SuccessResponse<bool>(result);
            }
            return new ErrorResponse<bool>(ResponseStatus.BadRequest, default, ResultMessage.Error);
        }

        public async Task<Response<IEnumerable<CommentResponse>>> Get()
        {
            var comments = await _commentRepository.Get();
            return new SuccessResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper)); 
        }

        public async Task<Response<IEnumerable<CommentResponse>>> GetAllByStatusIsFalse()
        {
            var comments = await _commentRepository.GetAllByStatusIsFalse();
            return new SuccessResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper));
        }

        public async Task<Response<IEnumerable<CommentResponse>>> GetByFoodName(string foodName)
        {
            var comments = await _commentRepository.GetByFoodName(foodName);
            return new SuccessResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper)); 
        }

        public async Task<Response<CommentResponse>> GetById(Guid id)
        {
            var isExist = await _commentRepository.IsExist(id);
            if(!isExist){
                return new ErrorResponse<CommentResponse>(ResponseStatus.NotFound,default,ResultMessage.NotFoundComment);
            }
            var comment = await _commentRepository.GetById(id);
            return new SuccessResponse<CommentResponse>(comment.ConvertToCommentResponse(_mapper)); 
        }

        public async Task<Response<bool>> Update(UpdateCommentRequest request)
        {
            var isExist = await _commentRepository.IsExist(request.Id);
            if(!isExist){
                return new ErrorResponse<bool>(ResponseStatus.NotFound,default,ResultMessage.NotFoundComment);
            }
            try
            {
                var comment = request.ConvertToComment(_mapper);
                UpdateCommentRequestValidator validator = new UpdateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentRepository.Update(comment);
                return new SuccessResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new ErrorResponse<bool>(ResponseStatus.BadRequest,default,ex.Message);
            }
        }
    }
}