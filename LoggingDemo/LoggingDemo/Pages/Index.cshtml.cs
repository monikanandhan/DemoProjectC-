using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public IndexModel(ILoggerFactory factory)
        //{
        //    _logger = factory.CreateLogger("DemoCategory");
        //}

        public void OnGet()
        {
            _logger.LogTrace("This is a trace log");
            _logger.LogDebug("this is a Debug log");
            _logger.LogInformation(LoggingId.DemoCode, "This is our first logged message");
            _logger.LogWarning("This is a warning Log");
            _logger.LogError("Thsi is a error log");
            _logger.LogCritical("This is a critical log");

            //_logger.LogError("server slow {time}", DateTime.Now);

            //try
            //{
            //    throw new Exception("you forgot to catch me");
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogCritical(ex, "there was a bad exception at {time}", DateTime.Now);
            //}

        }
    }
    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}
