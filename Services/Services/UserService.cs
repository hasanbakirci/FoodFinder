using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Result;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Services.Dtos.Requests.UserRequests;
using Services.Dtos.Responses.UserResponses;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService : IUserService
    {
        // ---
        private List<User> users = new List<User>{
            new User {Id=1,Name="admin",EmailAdress="admin@mail.com",Password="123",Role="Admin"},
            new User {Id=2,Name="hasan",EmailAdress="hasan@mail.com",Password="123",Role="Editor"},
        };
        private User IsValid(string email,string password){
          return users.FirstOrDefault(x => x.EmailAdress == email && x.Password == password);  
        }
        // ---

        public Response<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                LoginRequestValidator validator = new LoginRequestValidator();
                validator.ValidateAndThrow(request);
                var user = IsValid(request.EmailAdress, request.Password);
                if (user is null)
                {
                    return new ErrorResponse<LoginResponse>(ResponseStatus.BadRequest, default, ResultMessage.InvalidUserEmailOrPassword);

                }
                var claims = new[]{
                     new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                     new Claim(ClaimTypes.Role, user.Role)
                 };
                var issuer = "hasan";
                var audience = "hasan";
                var key = "qweqweqweqweqweqweasdasdsawqexzcxvxcvxcsdfsdrew";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: issuer,
                audience: audience, claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credential);
                var result = new LoginResponse{Token = new JwtSecurityTokenHandler().WriteToken(token)};
                return new SuccessResponse<LoginResponse>(result);
            }
            catch (Exception ex)
            {
                return new ErrorResponse<LoginResponse>(ResponseStatus.BadRequest,default,ex.Message);
            }
        }
    }
}