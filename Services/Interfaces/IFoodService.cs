using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Result;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.FoodResponses;

namespace Services.Interfaces
{
    public interface IFoodService
    {
        Task<Response<IEnumerable<FoodSimpleResponse>>> Get();
        Task<Response<FoodDetailResponse>> GetById(Guid id);
        Task<Response<Guid>> Create(CreateFoodRequest request);
        Task<Response<bool>> Update(UpdateFoodRequest request);
        Task<Response<bool>> Delete(Guid id);
        Task<Response<IEnumerable<FoodSimpleResponse>>> GetByCategoryName(string categoryName);
        Task<Response<IEnumerable<FoodSimpleResponse>>> GetByIngredients(string ingredient);
    }
}