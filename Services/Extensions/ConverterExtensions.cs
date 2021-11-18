using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models.Entities;
using Services.Dtos.Requests.CategoryRequests;
using Services.Dtos.Requests.CommentRequests;
using Services.Dtos.Requests.FoodRequests;
using Services.Dtos.Responses.CategoryResponses;
using Services.Dtos.Responses.CommentResponses;
using Services.Dtos.Responses.FoodResponses;

namespace Services.Extensions
{
    public static class ConverterExtensions
    {
        // CATEGORY
        public static IEnumerable<CategoryResponse> ConvertToCategoryListResponse(this IEnumerable<Category> categories, IMapper mapper){
            var responses = mapper.Map<IEnumerable<CategoryResponse>>(categories);
            return responses;
        }
        public static CategoryResponse ConvertToCategoryResponse(this Category category, IMapper mapper){
            var response = mapper.Map<CategoryResponse>(category);
            return response;
        }
        public static Category ConvertToCategory(this CreateCategoryRequest request, IMapper mapper){
            return mapper.Map<Category>(request);
        }
        public static Category ConvertToCategory(this UpdateCategoryRequest request, IMapper mapper){
            return mapper.Map<Category>(request);
        }
        // COMMENT
        public static IEnumerable<CommentResponse> ConvertToCommentListResponse(this IEnumerable<Comment> comment, IMapper mapper){
            var responses = mapper.Map<IEnumerable<CommentResponse>>(comment);
            return responses;
        }
        public static CommentResponse ConvertToCommentResponse(this Comment comment, IMapper mapper){
            var response = mapper.Map<CommentResponse>(comment);
            return response;
        }
        public static Comment ConvertToComment(this CreateCommentRequest request, IMapper mapper){
            return mapper.Map<Comment>(request);
        }
        public static Comment ConvertToComment(this UpdateCommentRequest request, IMapper mapper){
            return mapper.Map<Comment>(request);
        }
        // FOOD
        public static IEnumerable<FoodSimpleResponse> ConvertToFoodSimpleListResponse(this IEnumerable<Food> foods, IMapper mapper){
            var responses = mapper.Map<IEnumerable<FoodSimpleResponse>>(foods);
            return responses;
        }
        public static FoodDetailResponse ConvertToFoodDetailResponse(this Food food, IMapper mapper){
            var response = mapper.Map<FoodDetailResponse>(food);
            return response;
        }
        public static Food ConvertToFood(this CreateFoodRequest request, IMapper mapper){
            return mapper.Map<Food>(request);
        }
        public static Food ConvertToFood(this UpdateFoodRequest request, IMapper mapper){
            return mapper.Map<Food>(request);
        }
    }
}