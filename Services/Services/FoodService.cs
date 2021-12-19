using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Core.Helpers;
using Core.Result;
using Data.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.FoodResponses;
using Services.Extensions;
using Services.Interfaces;

namespace Services.Services
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

        public async Task<Response<Guid>> Create(CreateFoodRequest request)
        {
            // try
            // {
                var food = request.ConvertToFood(_mapper);
                CreateFoodRequestValidator validator = new CreateFoodRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _foodRepository.Create(food);
                return new SuccessResponse<Guid>(result);
            // }
            // catch (Exception ex)
            // {
            //     return new ErrorResponse<Guid>(ResponseStatus.BadRequest, default, ex.Message);
            // }
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var isExist = await _foodRepository.IsExist(id);
            if (!isExist)
            {
                return new ErrorResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            var result = await _foodRepository.Delete(id);
            if (result)
            {
                return new SuccessResponse<bool>(result);
            }
            return new ErrorResponse<bool>(ResponseStatus.BadRequest, default, ResultMessage.Error);
        }


        public async Task<Response<IEnumerable<FoodSimpleResponse>>> Get()
        {
            var foods = await _foodRepository.Get();
            return new SuccessResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<Response<IEnumerable<FoodSimpleResponse>>> GetByCategoryName(string categoryName)
        {
            var foods = await _foodRepository.GetByCategoryName(categoryName);
            return new SuccessResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<Response<FoodDetailResponse>> GetById(Guid id)
        {
            var isExist = await _foodRepository.IsExist(id);
            if (!isExist)
            {
                return new ErrorResponse<FoodDetailResponse>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            var food = await _foodRepository.GetById(id);
            return new SuccessResponse<FoodDetailResponse>(food.ConvertToFoodDetailResponse(_mapper));
        }

        public async Task<Response<IEnumerable<FoodSimpleResponse>>> GetByIngredients(string ingredient)
        {
            var foods = await _foodRepository.GetByIngredients(ingredient);
            return new SuccessResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
        }

        public async Task<Response<IEnumerable<FoodSimpleResponse>>> SearchForImage(IFormFile file)
        {
            
            var imagePath = await FileHelper.Add(file);
            var result = await PostAiApi(imagePath);
            if(result.Result is not null){
                var foods = await _foodRepository.GetByIngredients(result.Result);
                return new SuccessResponse<IEnumerable<FoodSimpleResponse>>(foods.ConvertToFoodSimpleListResponse(_mapper));
            }
            return new ErrorResponse<IEnumerable<FoodSimpleResponse>>(ResponseStatus.NotFound,default,"Kayıt bulunamadı.");  
        }

        public async Task<Response<bool>> Update(UpdateFoodRequest request)
        {
            var isExist = await _foodRepository.IsExist(request.Id);
            if (!isExist)
            {
                return new ErrorResponse<bool>(ResponseStatus.NotFound, default, ResultMessage.NotFoundFood);
            }
            // try
            // {
                var food = request.ConvertToFood(_mapper);
                UpdateFoodRequestValidator validator = new UpdateFoodRequestValidator();
                validator.ValidateAndThrow(request);
                var result = await _foodRepository.Update(food);
                return new SuccessResponse<bool>(result);
            // }
            // catch (Exception ex)
            // {
            //     return new ErrorResponse<bool>(ResponseStatus.BadRequest, default, ex.Message);
            // }
        }

        private async Task<AiResponse> PostAiApi(string path){
            string url = "http://127.0.0.1:8000/";
            var client = new HttpClient();

            var multiForm = new MultipartFormDataContent();
            FileStream fs = File.OpenRead(path);
            multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(path));

            
            HttpResponseMessage response = await client.PostAsync(url,multiForm);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AiResponse>(responseBody);
                Console.WriteLine("Filename: "+result.Filename +" Result: "+result.Result);
                return result;
            }
            return null;

        }
    }

    public class AiResponse{
        public string Filename { get; set; }
        public string Result { get; set; }
    }
}