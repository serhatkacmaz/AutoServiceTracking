using Core.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Service.Exceptions;
using System.Text.Json;

namespace WebApi.Infrastructure.Middelwares;

public static class GlobalExceptionHandler
{
    public static void UseGlobalException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var excepitonFeature = context.Features.Get<IExceptionHandlerFeature>();
                var statusCode = excepitonFeature.Error switch
                {
                    ClientSideException => StatusCodes.Status400BadRequest,
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.StatusCode = statusCode;

                var response = RequestResponse<NoContentData>.Fail(statusCode, excepitonFeature.Error.Message);
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
        });
    }
}
