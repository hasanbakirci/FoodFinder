using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ApiResult;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.FoodResponses;

namespace Services.Interfaces
{
    public interface IFoodService
    {
        Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> Get();
        Task<ApiResponse<FoodDetailResponse>> GetById(Guid id);
        Task<ApiResponse<Guid>> Create(CreateFoodRequest request);
        Task<ApiResponse<bool>> Update(UpdateFoodRequest request);
        Task<ApiResponse<bool>> Delete(Guid id);
        Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> GetByCategoryName(string categoryName);
        Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> GetByIngredients(string ingredient);
    }
}