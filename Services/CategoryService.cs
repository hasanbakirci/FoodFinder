using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApiResult;
using Data.Interfaces;
using FluentValidation;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Responses.CategoryResponses;
using Services.Extensions;
using Services.Interfaces;

namespace Services
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

        public async Task<ApiResponse<Guid>> Create(CreateCategoryRequest request)
        {
            try
            {
                var category = request.ConvertToCategory(_mapper);
                CreateCategoryRequestValidator validator = new CreateCategoryRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _categoryRepository.Create(category);
                return new SuccessApiResponse<Guid>(result);
            }
            catch (Exception ex)
            {

                return new ErrorApiResponse<Guid>(ResponseStatus.BadRequest, data: default, message: ex.Message);

            }
        }

        public async Task<ApiResponse<bool>> Delete(Guid id)
        {
            var isExist = await _categoryRepository.IsExist(id);
            if (!isExist)
            {

                return new ErrorApiResponse<bool>(ResponseStatus.NotFound, data: default, message: ResultMessage.NotFoundCategory);

            }
            var result = await _categoryRepository.Delete(id);

            if (result)
            {
                return new SuccessApiResponse<bool>(result);
            }
            return new ErrorApiResponse<bool>(ResponseStatus.BadRequest, data: default, message: ResultMessage.Error);
        }

        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> Get()
        {
            var categories = await _categoryRepository.Get();
            return new SuccessApiResponse<IEnumerable<CategoryResponse>>(categories.ConvertToCategoryListResponse(_mapper));
        }

        public async Task<ApiResponse<CategoryResponse>> GetById(Guid id)
        {
            var isExist = await _categoryRepository.IsExist(id);
            if (!isExist)
            {

                return new ErrorApiResponse<CategoryResponse>(ResponseStatus.NotFound, data: default, message: ResultMessage.NotFoundCategory);

            }
            var category = await _categoryRepository.GetById(id);
            return new SuccessApiResponse<CategoryResponse>(category.ConvertToCategoryResponse(_mapper));
        }

        public async Task<ApiResponse<bool>> Update(UpdateCategoryRequest request)
        {
            var isExist = await _categoryRepository.IsExist(request.Id);
            if (!isExist)
            {

                return new ErrorApiResponse<bool>(ResponseStatus.NotFound, data: default, message: ResultMessage.NotFoundCategory);

            }
            try
            {

                var category = request.ConvertToCategory(_mapper);
                UpdateCategoryRequestValidator validator = new UpdateCategoryRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _categoryRepository.Update(category);
                return new SuccessApiResponse<bool>(result);

            }
            catch (Exception ex)
            {

                return new ErrorApiResponse<bool>(ResponseStatus.BadRequest, data: default, message: ex.Message);

            }
        }
    }
}