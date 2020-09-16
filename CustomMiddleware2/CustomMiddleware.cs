using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CustomMiddleware2
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory  )
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Create logger");
            _logger.LogInformation("Custom middllware has started.");
        }

        public Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Custom middllware has completed.");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
