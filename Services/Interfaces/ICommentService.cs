using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ApiResult;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Responses.CommentResponses;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task<ApiResponse<IEnumerable<CommentResponse>>> Get();
        Task<ApiResponse<CommentResponse>> GetById(Guid id);
        Task<ApiResponse<Guid>> Create(CreateCommentRequest request);
        Task<ApiResponse<bool>> Update(UpdateCommentRequest request);
        Task<ApiResponse<bool>> Delete(Guid id);
        Task<ApiResponse<IEnumerable<CommentResponse>>> GetByFoodName(string foodName);
        Task<ApiResponse<IEnumerable<CommentResponse>>> GetAllByStatusIsFalse();
    }
}