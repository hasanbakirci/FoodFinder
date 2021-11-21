using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApiResult;
using Data.Repositories.CommentRepository;
using FluentValidation;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Responses.CommentResponses;
using Services.Extensions;

namespace Services.CommentServices
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

        public async Task<ApiResponse<Guid>> Create(CreateCommentRequest request)
        {
            try
            {
                var comment = request.ConvertToComment(_mapper);
                CreateCommentRequestValidator validator = new CreateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentRepository.Create(comment);
                return new SuccessApiResponse<Guid>(result);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse<Guid>(ResponseStatus.BadRequest, default, ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> Delete(Guid id)
        {
            var isExist = await _commentRepository.IsExist(id);
            if(!isExist){
                return new ErrorApiResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundComment);
            }
            var result = await _commentRepository.Delete(id);
            if(result){
                return new SuccessApiResponse<bool>(result);
            }
            return new ErrorApiResponse<bool>(ResponseStatus.BadRequest, default, ResultMessage.Error);
        }

        public async Task<ApiResponse<IEnumerable<CommentResponse>>> Get()
        {
            var comments = await _commentRepository.Get();
            return new SuccessApiResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper)); 
        }

        public async Task<ApiResponse<IEnumerable<CommentResponse>>> GetAllByStatusIsFalse()
        {
            var comments = await _commentRepository.GetAllByStatusIsFalse();
            return new SuccessApiResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper));
        }

        public async Task<ApiResponse<IEnumerable<CommentResponse>>> GetByFoodName(string foodName)
        {
            var comments = await _commentRepository.GetByFoodName(foodName);
            return new SuccessApiResponse<IEnumerable<CommentResponse>>(comments.ConvertToCommentListResponse(_mapper)); 
        }

        public async Task<ApiResponse<CommentResponse>> GetById(Guid id)
        {
            var isExist = await _commentRepository.IsExist(id);
            if(!isExist){
                return new ErrorApiResponse<CommentResponse>(ResponseStatus.NotFound,default,ResultMessage.NotFoundComment);
            }
            var comment = await _commentRepository.GetById(id);
            return new SuccessApiResponse<CommentResponse>(comment.ConvertToCommentResponse(_mapper)); 
        }

        public async Task<ApiResponse<bool>> Update(UpdateCommentRequest request)
        {
            var isExist = await _commentRepository.IsExist(request.Id);
            if(!isExist){
                return new ErrorApiResponse<bool>(ResponseStatus.NotFound,default,ResultMessage.NotFoundComment);
            }
            try
            {
                var comment = request.ConvertToComment(_mapper);
                UpdateCommentRequestValidator validator = new UpdateCommentRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _commentRepository.Update(comment);
                return new SuccessApiResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse<bool>(ResponseStatus.BadRequest,default,ex.Message);
            }
        }
    }
}