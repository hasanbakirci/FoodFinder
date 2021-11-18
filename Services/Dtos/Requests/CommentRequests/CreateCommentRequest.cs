using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Requests.CommentRequests
{
    public class CreateCommentRequest
    {
        public string Text { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public Guid FoodId { get; set; }
    }
}