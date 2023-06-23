using ExampleWebAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExampleAPI.Filters
{
    public class ErrorFilter : IExceptionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ErrorResponseFactory _errorResponseFactory;
        public ErrorFilter(IHttpContextAccessor httpContextAccessor , ErrorResponseFactory errorResponseFactory)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._errorResponseFactory = errorResponseFactory;
        }
        public void OnException(ExceptionContext context)
        {

            ProblemDetails problems = _errorResponseFactory.CreateProblemDetails(_httpContextAccessor.HttpContext);
            
            var resultar = new ObjectResult(problems);

        }
    }
}
