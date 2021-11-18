using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Services.Dtos.Requests.FoodRequests
{
    public class CreateFoodRequestValidator : AbstractValidator<CreateFoodRequest>
    {
        public CreateFoodRequestValidator()
        {
            RuleFor(req => req.CategoryId).NotEmpty();
            RuleFor(req => req.ImageUrl).NotEmpty().MinimumLength(2);
            RuleFor(req => req.Ingredients).NotEmpty().MinimumLength(5);
            RuleFor(req => req.Name).NotEmpty().MinimumLength(2).MaximumLength(200);
            RuleFor(req => req.Recipe).NotEmpty().MinimumLength(2);
        }
    }
}