
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public static class ExceptionHandlerExtensions
{
    public static void UseMyExceptionHander(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    var logger = loggerFactory.CreateLogger("ExceptionHandlerExtensions.UseMyExceptionHander");
                    logger.LogError(500, ex.Error, ex.Error.Message);
                }
                await context.Response.WriteAsync($"{ex?.Error?.Message}?? occurd");
            });
        });
    }
}