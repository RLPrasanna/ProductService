using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ProductService.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context,ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new { Message = "An Error Occured." };
            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response = new { Message = exception.Message };
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
