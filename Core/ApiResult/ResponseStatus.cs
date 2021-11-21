using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public enum ResponseStatus : int
    {
        Ok = 200,
        Created = 201,
        BadRequest = 400,
        UnAuthorized = 401,
        Forbid = 403,
        NotFound = 404,
        Internal = 500
    }
}