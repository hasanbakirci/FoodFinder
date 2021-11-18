using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Comment : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public bool Status { get; set; }
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}