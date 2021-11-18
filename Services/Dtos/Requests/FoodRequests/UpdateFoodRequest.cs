using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Requests.FoodRequests
{
    public class UpdateFoodRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Recipe { get; set; }
        public string Ingredients { get; set; }
        public Guid CategoryId { get; set; }
    }
}