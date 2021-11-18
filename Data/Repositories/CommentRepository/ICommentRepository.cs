using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Repositories.CommentRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByFoodName(string foodName);
    }
}