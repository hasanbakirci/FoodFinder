using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApiResult;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Responses.CategoryResponses;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryResponse>>> Get();
        Task<ApiResponse<CategoryResponse>> GetById(Guid id);
        Task<ApiResponse<Guid>> Create(CreateCategoryRequest request);
        Task<ApiResponse<bool>> Update(UpdateCategoryRequest request);
        Task<ApiResponse<bool>> Delete(Guid id);
    }
}