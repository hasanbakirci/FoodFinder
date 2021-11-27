using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Result;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Responses.CategoryResponses;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<IEnumerable<CategoryResponse>>> Get();
        Task<Response<CategoryResponse>> GetById(Guid id);
        Task<Response<Guid>> Create(CreateCategoryRequest request);
        Task<Response<bool>> Update(UpdateCategoryRequest request);
        Task<Response<bool>> Delete(Guid id);
    }
}