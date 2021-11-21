using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            
        }
        public ApiResponse(ResponseStatus status, string message)
        {
            StatusCode = (int)status;
            Success = StatusCode < 400;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }


    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(ResponseStatus status, string message) : base(status,message)
        {
            
        }
        public T Data{get;set;}
    }
}