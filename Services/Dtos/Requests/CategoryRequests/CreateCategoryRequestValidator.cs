using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Services.Dtos.Requests.CategoryRequests
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(req => req.Name).NotEmpty().MinimumLength(2).MaximumLength(150);
        }
    }
}