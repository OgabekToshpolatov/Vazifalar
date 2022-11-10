namespace logger.Logger;

public class LoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
       return new MyFileLogger();
    }

    public void Dispose()
    {
        
    }
}