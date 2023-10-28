using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Middlewares;

public static class ExceptionMiddlewareHelper
{
    public static async Task SetErrorResponse(ProblemDetails problemDetails, HttpContext context)
    {
        context.Response.StatusCode = (int)problemDetails.Status!;
        
        string json = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(json);
    }
}