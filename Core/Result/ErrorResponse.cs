
namespace Core.Result
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(ResponseStatus status, string message) : base(status, message: message)
        {
        }

        public ErrorResponse(string message) : base(ResponseStatus.BadRequest, message)
        {
        }
    }

    public class ErrorResponse<T> : Response<T>
    {
        public ErrorResponse(ResponseStatus status, T data, string message) : base(status, message: message)
        {
            Data = data;
        }

        public ErrorResponse(T data, string message) : base(ResponseStatus.BadRequest, message)
        {
            Data = data;
        }
    }
}