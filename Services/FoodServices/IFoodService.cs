using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.FoodResponses;

namespace Services.FoodServices
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodSimpleResponse>> Get();
        Task<FoodDetailResponse> GetById(Guid id);
        Task<Guid> Create(CreateFoodRequest request);
        Task<bool> Update(UpdateFoodRequest request);
        Task<bool> Delete(Guid id);
        Task<bool> FoodIsExist(Guid id);
        Task<IEnumerable<FoodSimpleResponse>> GetByCategoryName(string categoryName);
        Task<IEnumerable<FoodSimpleResponse>> GetByIngredients(string ingredient);
    }
}