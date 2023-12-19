using Microsoft.AspNetCore.Http;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace Todos.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
       
        private readonly RequestDelegate _next;

     
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                // log the error
                
                var response = context.Response;
                response.ContentType = "application/json";

                // get the response code and message
                
                response.StatusCode = (int)404;
                //await response.WriteAsync(JsonSerializer.Deserialize(exception));
            }
        }
    }
}
