using Application.Commons.Mediator;
using Application.Commons.Resources;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class InputActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("input", out var inputObj) && inputObj is BaseInput input)
        {
            input.SetUserId(GetUserId(context));
            input.SetHostUrl(GetHostUrl(context));
            input.SetLoggedUserId(GetLoggedUserId(context));
            input.SetAcceptLanguage(GetAcceptLanguage(context));
        }

        await next();
    }

    private string GetHostUrl(ActionExecutingContext context)
    {
        var httpContext = context?.HttpContext;
        var request = httpContext?.Request;

        if (request == null)
            return string.Empty;

        return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
    }

    private string GetAcceptLanguage(ActionExecutingContext context)
    {
        var httpContext = context?.HttpContext;
        var request = httpContext?.Request;

        if (request == null)
            return string.Empty;

        var acceptLanguage = request.GetTypedHeaders().AcceptLanguage;
        string correctAcceptLanguage = SupportedCulture.GetCorrectAcceptLanguage(acceptLanguage);
        return correctAcceptLanguage;
    }

    private int? GetUserId(ActionExecutingContext context)
    {
        var httpContext = context?.HttpContext;
        var request = httpContext?.Request;
        var routeValues = request?.RouteValues;

        if (routeValues == null || !routeValues.ContainsKey("userId"))
            return null;
        
        routeValues.TryGetValue("userId", out var userIdObj);
        int userId = int.Parse(userIdObj.ToString());
        return userId;
    }

    private int GetLoggedUserId(ActionExecutingContext context)
    {
        var httpContext = context?.HttpContext;
        var user = httpContext?.User;
        var claims = user?.Claims;

        if (claims == null || !claims.Any(x => x.Type == "id"))
            return int.MinValue;

        return int.Parse(claims.Single(x => x.Type == "id").Value);
    }
}