using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Galaxy.MVC.Filter.Middleware
{
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(
            this IApplicationBuilder builder,string errorHandlingPath)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>
                (Options.Create(new ExceptionHandlerOptions
                {
                    ExceptionHandlingPath = new PathString(errorHandlingPath)
                }));
        }
    }
}
