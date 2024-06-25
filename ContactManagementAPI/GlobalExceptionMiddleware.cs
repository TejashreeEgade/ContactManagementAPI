using System.Net;
using ContactManagementAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ContactManagementAPI
{
    public class GlobalExceptionMiddleware : IExceptionGlobalWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        //public GlobalExceptionMiddleware(, ILogger<GlobalExceptionMiddleware> logger)
        //{
        //    _next = requestDelegate;
        //    _logger = logger;
        //}
        public async Task InvokeSync(HttpContext context, RequestDelegate _next)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                _logger.LogError(ex, "An unhandled exception occured");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex) { 
            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                error = new
                {
                    message = "Someting Went Wrong. Please try again later",
                    details = ex.Message

                }
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
