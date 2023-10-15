using Application.Commons.Mediator;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.ActionFilters;

public class InputActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("input", out var inputObj) && inputObj is BaseInput input)
        {
            var userIdInfo = GetUserIdInfo(context);
            input.SetHostUrl(GetHostUrl(context));
            input.SetUserId(userIdInfo.Item1);
            input.SetIsUserIdProvided(userIdInfo.Item2);
            input.SetLoggedUserId(GetLoggedUserId(context));
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

    private (int, bool) GetUserIdInfo(ActionExecutingContext context)
    {
        var httpContext = context?.HttpContext;
        var request = httpContext?.Request;
        var routeValues = request?.RouteValues;

        if (routeValues == null || !routeValues.ContainsKey("userId"))
            return (int.MinValue, false);
        
        routeValues.TryGetValue("userId", out var userIdObj);
        int userId = int.Parse(userIdObj.ToString());
        return (userId, true);
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