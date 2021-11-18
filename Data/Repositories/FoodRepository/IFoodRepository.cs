using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Repositories.FoodRepository
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<IEnumerable<Food>> GetByCategoryName(string categoryName);
        Task<IEnumerable<Food>> GetByIngredients(string ingredient);
    }
}