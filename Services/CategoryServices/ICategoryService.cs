using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Responses.CategoryResponses;

namespace Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> Get();
        Task<CategoryResponse> GetById(Guid id);
        Task<Guid> Create(CreateCategoryRequest request);
        Task<bool> Update(UpdateCategoryRequest request);
        Task<bool> Delete(Guid id);
    }
}