using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entities;

namespace Services.Dtos.Responses.CommentResponses
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public bool Status { get; set; }
        public string FoodName { get; set; }
    }
}