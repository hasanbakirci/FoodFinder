using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApiResult;
using Data.Repositories.FoodRepository;
using FluentValidation;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.FoodResponses;
using Services.Extensions;

namespace Services.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> Create(CreateFoodRequest request)
        {
            try
            {
                var food = request.ConvertToFood(_mapper);
                CreateFoodRequestValidator validator = new CreateFoodRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _foodRepository.Create(food);
                return new SuccessApiResponse<Guid>(result);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse<Guid>(ResponseStatus.BadRequest, default, ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> Delete(Guid id)
        {
            var isExist = await _foodRepository.IsExist(id);
            if (!isExist)
            {
                return new ErrorApiResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            var result = await _foodRepository.Delete(id);
            if (result)
            {
                return new SuccessApiResponse<bool>(result);
            }
            return new ErrorApiResponse<bool>(ResponseStatus.BadRequest, default, ResultMessage.Error);
        }


        public async Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> Get()
        {
            var foods = await _foodRepository.Get();
            return new SuccessApiResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> GetByCategoryName(string categoryName)
        {
            var foods = await _foodRepository.GetByCategoryName(categoryName);
            return new SuccessApiResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<ApiResponse<FoodDetailResponse>> GetById(Guid id)
        {
            var isExist = await _foodRepository.IsExist(id);
            if (!isExist)
            {
                return new ErrorApiResponse<FoodDetailResponse>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            var food = await _foodRepository.GetById(id);
            return new SuccessApiResponse<FoodDetailResponse>(food.ConvertToFoodDetailResponse(_mapper));
        }

        public async Task<ApiResponse<IEnumerable<FoodSimpleResponse>>> GetByIngredients(string ingredient)
        {
            var foods = await _foodRepository.GetByIngredients(ingredient);
            return new SuccessApiResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<ApiResponse<bool>> Update(UpdateFoodRequest request)
        {
            var isExist = await _foodRepository.IsExist(request.Id);
            if (!isExist)
            {
                return new ErrorApiResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            try
            {
                var food = request.ConvertToFood(_mapper);
                UpdateFoodRequestValidator validator = new UpdateFoodRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _foodRepository.Update(food);
                return new SuccessApiResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse<bool>(ResponseStatus.BadRequest, default, ex.Message);
            }
        }
    }
}