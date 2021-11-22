using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByFoodName(string foodName);
        Task<IEnumerable<Comment>> GetAllByStatusIsFalse();
    }
}