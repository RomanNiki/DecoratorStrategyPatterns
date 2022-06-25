namespace DecoratorStrategyPatterns;

public interface ILogger
{
    void WriteLog(string message);
}

public interface ILogPolicy
{
    bool NeedLog();
}

public class DefaultLogPolicy : ILogPolicy
{
    public bool NeedLog()
    {
        return true;
    }
}

public class OnlyFridayLogPolicy : ILogPolicy
{
    public bool NeedLog()
    {
        return DateTime.Now.DayOfWeek == DayOfWeek.Friday;
    }
}

public class ChainOfLogPolicy : ILogPolicy
{
    private readonly IEnumerable<ILogPolicy> _policies;

    public ChainOfLogPolicy(IEnumerable<ILogPolicy> policies)
    {
        _policies = policies;
    }

    public static ChainOfLogPolicy Create(params ILogPolicy[] policies)
    {
        return new ChainOfLogPolicy(policies);
    }

    public bool NeedLog()
    {
        return _policies.Any(policy => policy.NeedLog());
    }
}

public class ConsoleLogWriter : ILogger
{
    private readonly ILogPolicy _logPolicy;
    private readonly ILogger _logger;

    public ConsoleLogWriter(ILogPolicy logPolicy, ILogger logger = null)
    {
        _logPolicy = logPolicy;
        _logger = logger;
    }

    public void WriteLog(string message)
    {
        _logger?.WriteLog(message);
        if (_logPolicy.NeedLog())
        {
            Console.WriteLine(message);
        }
    }
}

public class FileLogWriter : ILogger
{
    private readonly ILogPolicy _logPolicy;
    private readonly ILogger _logger;

    public FileLogWriter(ILogPolicy logPolicy, ILogger logger = null)
    {
        _logPolicy = logPolicy;
        _logger = logger;
    }

    public void WriteLog(string message)
    {
        _logger?.WriteLog(message);
        if (_logPolicy.NeedLog())
        {
            File.WriteAllText("log.txt", message);
        }
    }
}