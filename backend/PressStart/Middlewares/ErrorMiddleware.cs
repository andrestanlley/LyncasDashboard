using Newtonsoft.Json;
using PressStart.Dtos.Response;
using PressStart.Functions;

namespace PressStart.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadHttpRequestException ex)
            {
                ExcecaoResponse ExResponse = new(ex.HResult, ex.Message, ex.StatusCode);
                await HandleExceptionAsync(context, ExResponse);
            }
            catch (Exception ex)
            {
                string Message = ChecarErro.HResult(ex.HResult, ex.Message);
                ExcecaoResponse ExResponse = new(ex.HResult, Message);
                await HandleExceptionAsync(context, ExResponse);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, ExcecaoResponse ex)
        {
            context.Response.StatusCode = ex.statusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
        }
    }
}