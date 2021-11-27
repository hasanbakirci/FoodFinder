using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Result;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context){

            var watch = Stopwatch.StartNew();

            try
            {

                string message = "[Request]  HTTP "+ context.Request.Method + " - "+ context.Request.Path + " Date: "+DateTime.Now;;

                _loggerService.WriteLog(message);

                await _next(context);
                watch.Stop();

                message ="[Response] HTTP "+ context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + 
                      " in "+watch.Elapsed.TotalMilliseconds +"ms Date: "+DateTime.Now;
                _loggerService.WriteLog(message);
            }
            catch (Exception e)
            {
                watch.Stop();

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string message = "[Error]    HTTP "+ context.Request.Method + " - " + context.Request.Path + " - "+ context.Response.StatusCode +
                                    " Error Message " +e.Message + " in "+ watch.Elapsed.TotalMilliseconds+ "ms Date: "+DateTime.Now;
                _loggerService.WriteLog(message);

                var resp = new ErrorResponse(ResponseStatus.Internal,e.Message);
                var result = JsonSerializer.Serialize(resp);

                await response.WriteAsync(result);
                
            }
        }
    }
}