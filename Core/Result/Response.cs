
namespace Core.Result
{
    public class Response
    {
        public Response()
        {
            
        }
        public Response(ResponseStatus status, string message)
        {
            StatusCode = (int)status;
            Success = StatusCode < 400;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }


    public class Response<T> : Response
    {
        public Response(ResponseStatus status, string message) : base(status,message)
        {
            
        }
        public T Data{get;set;}
    }
}