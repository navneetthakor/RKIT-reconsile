using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogManagementSystem.Filters
{
    /// <summary>
    /// Action filter for logging action execution details.
    /// </summary>
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogActionFilter"/> class.
        /// </summary>
        /// <param name="logger">Logger instance for logging action details.</param>
        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">Context for action executing.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Executing action: {context.ActionDescriptor.DisplayName}");
        }

        /// <summary>
        /// Called after the action method has been invoked.
        /// </summary>
        /// <param name="context">Context for action executed.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _logger.LogError($"Error occurred during action execution: {context.Exception.Message}");
            }
            else
            {
                _logger.LogInformation($"Action executed successfully: {context.ActionDescriptor.DisplayName}");
            }
        }
    }
}