using System.Net;

namespace BlogManagementSystem.Middleware
{
    /// <summary>
    /// Middleware for handling exceptions globally.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">Logger instance for logging exceptions.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware to handle the HTTP request.
        /// </summary>
        /// <param name="context">HTTP context of the current request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware in the pipeline.
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unhandled exception occurred: {ex.Message}"); // Log the exception.
                await HandleExceptionAsync(context, ex); // Handle the exception by sending a response.
            }
        }

        /// <summary>
        /// Handles the exception by setting the response details.
        /// </summary>
        /// <param name="context">HTTP context of the current request.</param>
        /// <param name="exception">The caught exception.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json"; // Set response content type to JSON.
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Set response status code to 500.

            // Create and return the error response.
            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later."
            }.ToString());
        }
    }
}