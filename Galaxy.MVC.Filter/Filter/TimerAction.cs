using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.MVC.Filter.Filter
{
    public class TimerAction : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly ILogger _logger;

        public TimerAction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TimeActionFilterLogger");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            _logger.LogInformation("Action executed - elapsed time: " + _stopwatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
            _stopwatch.Stop();
            var elapsed = Encoding.ASCII.GetBytes(_stopwatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
        }
    }
}
