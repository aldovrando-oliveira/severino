using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Severino.Extensions.Logging.Middlewares;

namespace Severino.Extensions.Logging
{
    public static class LoggerHandlerExtensions
    {
        public static void AddLoggerMiddleware(this IServiceCollection services)   
        {
            services.AddTransient<LoggerMiddleware>();
        }

        public static void UseLoggerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggerMiddleware>();
        }   
    }
}