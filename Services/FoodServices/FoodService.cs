using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.FoodRepository;
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

        public async Task<Guid> Create(CreateFoodRequest request)
        {
            var food = request.ConvertToFood(_mapper);
            return await _foodRepository.Create(food);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _foodRepository.Delete(id);
        }

        public async Task<bool> FoodIsExist(Guid id)
        {
            return await _foodRepository.IsExist(id);
        }

        public async Task<IEnumerable<FoodSimpleResponse>> Get()
        {
            var foods = await _foodRepository.Get();
            return foods.ConvertToFoodSimpleListResponse(_mapper);
        }

        public async Task<IEnumerable<FoodSimpleResponse>> GetByCategoryName(string categoryName)
        {
            var foods = await _foodRepository.GetByCategoryName(categoryName);
            return foods.ConvertToFoodSimpleListResponse(_mapper);
        }

        public async Task<FoodDetailResponse> GetById(Guid id)
        {
            var food = await _foodRepository.GetById(id);
            return food.ConvertToFoodDetailResponse(_mapper);
        }

        public async Task<IEnumerable<FoodSimpleResponse>> GetByIngredients(string ingredient)
        {
            var foods = await _foodRepository.GetByIngredients(ingredient);
            return foods.ConvertToFoodSimpleListResponse(_mapper);
        }

        public async Task<bool> Update(UpdateFoodRequest request)
        {
            var food = request.ConvertToFood(_mapper);
            return await _foodRepository.Update(food);
        }
    }
}