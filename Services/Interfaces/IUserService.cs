using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApiResult;
using Services.Dtos.Requests.UserRequests;
using Services.Dtos.Responses.UserResponses;

namespace Services.Interfaces
{
    public interface IUserService
    {
        ApiResponse<LoginResponse> Login(LoginRequest request);
    }
}