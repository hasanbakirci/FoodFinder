using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Services.Dtos.Requests.CommentRequests
{
    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidator()
        {
            RuleFor(req => req.Email).NotEmpty().EmailAddress();
            RuleFor(req => req.Nickname).NotEmpty().MinimumLength(2).MaximumLength(200);
            RuleFor(req => req.FoodId).NotEmpty();
            RuleFor(req => req.Text).NotEmpty().MinimumLength(1);
        }
    }
}