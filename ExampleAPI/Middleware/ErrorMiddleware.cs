using ExampleWebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExampleAPI.Middleware
{
    public class ErrorMiddleware : IMiddleware
    {
        private readonly ErrorResponseFactory _errorResponseFactory;
        public ErrorMiddleware(ErrorResponseFactory errorResponseFactory)
        {
            this._errorResponseFactory = errorResponseFactory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }
           
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                ProblemDetails problem = _errorResponseFactory.CreateProblemDetails(context, 500, "Error al realizar la request.", "", $"{ex.Message}-{ex.InnerException}");

                var result = JsonSerializer.Serialize(problem);
                await response.WriteAsync(result);

            }


        }
    }
}
