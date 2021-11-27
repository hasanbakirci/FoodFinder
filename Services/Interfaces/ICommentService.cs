using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Result;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Responses.CommentResponses;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task<Response<IEnumerable<CommentResponse>>> Get();
        Task<Response<CommentResponse>> GetById(Guid id);
        Task<Response<Guid>> Create(CreateCommentRequest request);
        Task<Response<bool>> Update(UpdateCommentRequest request);
        Task<Response<bool>> Delete(Guid id);
        Task<Response<IEnumerable<CommentResponse>>> GetByFoodName(string foodName);
        Task<Response<IEnumerable<CommentResponse>>> GetAllByStatusIsFalse();
    }
}