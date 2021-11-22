using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Interfaces
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<IEnumerable<Food>> GetByCategoryName(string categoryName);
        Task<IEnumerable<Food>> GetByIngredients(string ingredient);
    }
}