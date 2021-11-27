using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Result;
using Services.Dtos.Requests.UserRequests;
using Services.Dtos.Responses.UserResponses;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Response<LoginResponse> Login(LoginRequest request);
    }
}