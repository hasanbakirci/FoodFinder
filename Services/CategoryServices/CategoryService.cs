using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.CategoryRepository;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Responses.CategoryResponses;
using Services.Extensions;

namespace Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryIsExist(Guid id)
        {
            return await _categoryRepository.IsExist(id);
        }

        public async Task<Guid> Create(CreateCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            return await _categoryRepository.Create(category);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<CategoryResponse>> Get()
        {
            var categories = await _categoryRepository.Get();
            return categories.ConvertToCategoryListResponse(_mapper);

        }

        public async Task<CategoryResponse> GetById(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            return category.ConvertToCategoryResponse(_mapper);
        }

        public async Task<bool> Update(UpdateCategoryRequest request)
        {
            var category = request.ConvertToCategory(_mapper);
            return await _categoryRepository.Update(category);
        }
    }
}