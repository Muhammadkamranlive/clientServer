using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseMicroSerivce.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                await HandleUnauthorizedAsync(context);
            }
            else if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                await HandleForbiddenAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Handle the exception and set the response status code accordingly
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new { error = ex.Message };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }

        private static Task HandleUnauthorizedAsync(HttpContext context)
        {
            // Handle the unauthorized error and set the response status code accordingly
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new { error = $"Error: Unauthorized {context.Response.StatusCode} content type {context.Response.StatusCode}" };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }

        private static Task HandleForbiddenAsync(HttpContext context)
        {
            // Handle the forbidden error and set the response status code accordingly
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "application/json";

            var response = new { error = $"Error: Forbidden Access {context.Response.StatusCode} content type {context.Response.StatusCode}" };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }
}
