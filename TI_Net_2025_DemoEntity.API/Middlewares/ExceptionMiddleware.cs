using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TI_Net_2025_DemoEntity.BLL.Exceptions;

namespace TI_Net_2025_DemoEntity.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);

            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        public async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode = 400;

            switch (ex)
            {
                case DemoEntityException e:
                    await SendResponse(context, e);
                    break;
                case Exception:
                    statusCode = 500;
                    context.Response.StatusCode = statusCode;

                    var response = new
                    {
                        message = ex.Message,
                    };

                    var jsonResponse = JsonSerializer.Serialize(response);

                    await context.Response.WriteAsync(jsonResponse);
                    break;
                default:
                    throw new Exception("WTF");
            }
        }

        public async Task SendResponse(HttpContext context, DemoEntityException ex)
        {
            context.Response.StatusCode = ex.StatusCode;

            var response = new
            {
                content = ex.Content
            };

            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
