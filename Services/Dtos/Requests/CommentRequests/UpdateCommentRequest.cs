using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Requests.CommentRequests
{
    public class UpdateCommentRequest
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
    }
}