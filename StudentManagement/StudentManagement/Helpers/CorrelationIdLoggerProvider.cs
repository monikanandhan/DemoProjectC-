namespace StudentManagement.Helpers
{

    using Newtonsoft.Json;

    public class CorrelationIdLoggerProvider : ILoggerProvider
    {
        private readonly HttpContextAccessor _httpContextAccessor;
        public CorrelationIdLoggerProvider()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new CorrelationIdLogger(_httpContextAccessor);
        }
        public void Dispose()
        {



        }

    }




    public class CorrelationIdLogger : ILogger
    {
        private readonly HttpContextAccessor _httpContextAccessor;



        public CorrelationIdLogger(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }



        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // Retrieve the CorrelationId from the logging scope and include it in the log message
            var correlationId = _httpContextAccessor?.HttpContext?.Request?.Headers["X-Correlation-ID"].ToString()
                ?? Guid.NewGuid().ToString();
            //if (string.IsNullOrEmpty(correlationId) || string.IsNullOrWhiteSpace(correlationId))
            //{
            //    correlationId = Guid.NewGuid().ToString();
            //}



            var loggerInfo = new LoggerInfo
            {
                Message = "StudentManagement",
                Description = formatter(state, exception),
                MethodName = "AccessOne.Core.Account.Program",
                CorrelationId = correlationId,
                RequestId = Guid.NewGuid().ToString(),
                EventTime = DateTime.Now,
                SourceSystem = Environment.MachineName,
                MachineName = Environment.MachineName,
                ServiceName = "AccessOne.Core.Account",
                ThreadId = Environment.CurrentManagedThreadId,
                UserName = Environment.UserName,
            };



            var message = JsonConvert.SerializeObject(loggerInfo, Formatting.None);
            Console.WriteLine(message);
        }
    }

   
}
