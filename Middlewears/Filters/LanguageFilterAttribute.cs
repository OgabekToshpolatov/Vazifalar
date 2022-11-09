using Microsoft.AspNetCore.Mvc.Filters;

namespace middlewears.Filters;

public class LanguageFilterAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestCulture.RequestLanguage = context.HttpContext.Request.Headers.First(h => h.Key == "Lang").Value;

        if (RequestCulture.RequestLanguage != "uz" && RequestCulture.RequestLanguage != "en")
        {
            throw new LanguageNotSupportedException();
        }
    }
}

public class LanguageNotSupportedException : Exception
{
    public LanguageNotSupportedException() : base ("Only 'uz', 'en'") { }
}