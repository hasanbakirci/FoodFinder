using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse(ResponseStatus status, string message) : base(status, message: message)
        {
        }

        public ErrorApiResponse(string message) : base(ResponseStatus.BadRequest, message)
        {
        }
    }

    public class ErrorApiResponse<T> : ApiResponse<T>
    {
        public ErrorApiResponse(ResponseStatus status, T data, string message) : base(status, message: message)
        {
            Data = data;
        }

        public ErrorApiResponse(T data, string message) : base(ResponseStatus.BadRequest, message)
        {
            Data = data;
        }
    }
}