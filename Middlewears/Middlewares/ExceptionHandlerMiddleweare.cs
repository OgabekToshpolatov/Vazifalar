namespace middlewears.Middlewares;

public class ExceptionHandlerMiddleweare
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleweare(RequestDelegate next)
    {
        _next = next ; 
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext); // hederidagi exceptionlarni oladi.
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new { error = e.Message });

            using var client = new HttpClient();
            var result = await client.GetAsync($"https://api.telegram.org/bot5607955006:AAGHBStoV2pffc9lmuvlpQ_a7UgrU8JYcmM/sendmessage?chat_id=-827851635&text={e}");

        }
    }
}