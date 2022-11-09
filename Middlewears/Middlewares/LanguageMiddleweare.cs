namespace middlewears.Middlewares;

public class LanguageMiddleweare
{
    private readonly RequestDelegate _next;

    public LanguageMiddleweare(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.ContainsKey("Lang"))
        {
            throw new Exception("Language header missed!");
        }

        RequestCulture.RequestLanguage = httpContext.Request.Headers["Lang"];
        return _next(httpContext);
    }   
}