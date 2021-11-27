
namespace Core.Result
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(ResponseStatus status, string message) : base(status,message)
        {
            
        }
        public SuccessResponse(ResponseStatus status) : base(status, ResultMessage.Success)
        {
            
        }
        public SuccessResponse() : base(ResponseStatus.Ok,ResultMessage.Success)
        {
            
        }
    }

    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse(ResponseStatus status, T data, string message) : base(status, message)
        {
            Data = data;
        }

        public SuccessResponse(ResponseStatus status, T data) : base(status, ResultMessage.Success)
        {
            Data = data;
        }

        public SuccessResponse(T data) : base(ResponseStatus.Ok, ResultMessage.Success)
        {
            Data = data;
        }
    }
          
}