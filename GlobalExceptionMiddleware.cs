using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ContactManagementAPI
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate requestDelegate, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }
        public async Task InvokeSync(HttpContext context)
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
