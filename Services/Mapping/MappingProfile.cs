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

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CATEGORY
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category,CategoryResponse>();
            // COMMENT
            CreateMap<CreateCommentRequest, Comment>();
            CreateMap<UpdateCommentRequest, Comment>();
            CreateMap<Comment,CommentResponse>().ForMember(dest => dest.FoodName, opt => opt.MapFrom(src => src.Food.Name));
            // FOOD
            CreateMap<CreateFoodRequest, Food>();
            CreateMap<UpdateFoodRequest, Food>();
            CreateMap<Food, FoodSimpleResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Food, FoodDetailResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                                 .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
        }
    }
}