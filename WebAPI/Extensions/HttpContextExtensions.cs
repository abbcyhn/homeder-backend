namespace WebAPI.Extensions;

public static class HttpContextExtensions
{
    public static int GetUserId(this HttpContext httpContext)
    {
        if (httpContext == null || httpContext.User == null)
        {
            return -1;
        }

        return int.Parse(httpContext.User.Claims.Single(x => x.Type == "id").Value);
    } 
}
