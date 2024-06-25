namespace ContactManagementAPI.Service.Interface
{
    public interface IExceptionGlobalWare
    {
        public Task InvokeSync(HttpContext context, RequestDelegate _next);

    }
}
