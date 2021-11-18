using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos.Responses.CommentResponses;

namespace Services.Dtos.Responses.FoodResponses
{
    public class FoodDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Recipe { get; set; }
        public string Ingredients { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryName { get; set; }
        public ICollection<CommentResponse> Comments { get; set; }
    }
}