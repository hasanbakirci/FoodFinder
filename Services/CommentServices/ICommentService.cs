using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Responses.CommentResponses;

namespace Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponse>> Get();
        Task<CommentResponse> GetById(Guid id);
        Task<Guid> Create(CreateCommentRequest request);
        Task<bool> Update(UpdateCommentRequest request);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<CommentResponse>> GetByFoodName(string foodName);
    }
}