using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.CommentRepository;
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

        public async Task<Guid> Create(CreateCommentRequest request)
        {
            var comment = request.ConvertToComment(_mapper);
            return await _commentRepository.Create(comment);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _commentRepository.Delete(id);
        }

        public async Task<IEnumerable<CommentResponse>> Get()
        {
            var comments = await _commentRepository.Get();
            return comments.ConvertToCommentListResponse(_mapper);
        }

        public async Task<IEnumerable<CommentResponse>> GetByFoodName(string foodName)
        {
            var comments = await _commentRepository.GetByFoodName(foodName);
            return comments.ConvertToCommentListResponse(_mapper);
        }

        public async Task<CommentResponse> GetById(Guid id)
        {
            var comment = await _commentRepository.GetById(id);
            return comment.ConvertToCommentResponse(_mapper);
        }

        public async Task<bool> Update(UpdateCommentRequest request)
        {
            var comment = request.ConvertToComment(_mapper);
            return await _commentRepository.Update(comment);
        }
    }
}