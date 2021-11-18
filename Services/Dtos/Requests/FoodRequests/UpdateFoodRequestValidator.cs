using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Services.Dtos.Requests.FoodRequests
{
    public class UpdateFoodRequestValidator : AbstractValidator<UpdateFoodRequest>
    {
        public UpdateFoodRequestValidator()
        {
            RuleFor(req => req.ImageUrl).MinimumLength(2);
            RuleFor(req => req.Ingredients).MinimumLength(5);
            RuleFor(req => req.Name).MinimumLength(2).MaximumLength(200);
            RuleFor(req => req.Recipe).MinimumLength(2);
        }
    }
}