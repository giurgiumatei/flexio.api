using Flexio.Data.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flexio.API.Middleware
{
    public class CustomErrorHandling
    {
        private readonly RequestDelegate Next;
        private const string ContentType = "application/json";

        public CustomErrorHandling(RequestDelegate next)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (CustomApplicationException ex)
            {
                await BuildResponse(context, ex.Message);
            }
            catch (AggregateException aggregateException)
            {
                List<object> exceptionList = aggregateException.InnerExceptions.Select(e => JsonSerializer.Deserialize<object>(e.Message)).ToList();

                await BuildResponse(context, JsonSerializer.Serialize(exceptionList));
            }
        }

        private static async Task BuildResponse(HttpContext context, string message)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = ContentType;
            await context.Response.WriteAsync(message);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorHandling>();
        }
    }
}
