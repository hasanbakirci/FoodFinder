using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Services.Dtos.Requests.UserRequests
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(req => req.EmailAdress).NotEmpty().EmailAddress().MinimumLength(5).MaximumLength(30);;
            RuleFor(req => req.Password).NotEmpty().MinimumLength(2).MaximumLength(30);
        }
    }
}