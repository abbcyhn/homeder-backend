using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Middlewares;

public class ProdExcHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (DbUpdateException e)
        {
            await ExceptionMiddlewareHelper.SetErrorResponse(
                new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                    Title = "Technical Error",
                },
                context
            );
        }
        catch (UnauthorizedAccessException e)
        {
            await ExceptionMiddlewareHelper.SetErrorResponse(
                new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                    Title = e.Message
                },
                context
            );
        }
        catch (Exception)
        {
            await ExceptionMiddlewareHelper.SetErrorResponse(
                new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error"
                },
                context
            );
        }
    }
}