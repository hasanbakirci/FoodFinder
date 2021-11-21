using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public class SuccessApiResponse : ApiResponse
    {
        public SuccessApiResponse(ResponseStatus status, string message) : base(status,message)
        {
            
        }
        public SuccessApiResponse(ResponseStatus status) : base(status, ResultMessage.Success)
        {
            
        }
        public SuccessApiResponse() : base(ResponseStatus.Ok,ResultMessage.Success)
        {
            
        }
    }

    public class SuccessApiResponse<T> : ApiResponse<T>
    {
        public SuccessApiResponse(ResponseStatus status, T data, string message) : base(status, message)
        {
            Data = data;
        }

        public SuccessApiResponse(ResponseStatus status, T data) : base(status, ResultMessage.Success)
        {
            Data = data;
        }

        public SuccessApiResponse(T data) : base(ResponseStatus.Ok, ResultMessage.Success)
        {
            Data = data;
        }
    }
          
}