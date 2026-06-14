using BusinessLogicLayer.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fundooNotes.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;

        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var statusCode = StatusCodes.Status500InternalServerError;
            var title = "Server Error";

            if (exception is NotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                title = "Not Found";
            }
            if (exception is ValidationException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                title = "Validation Failed";
            }
            if (exception is ConflictException)
            {
                statusCode = StatusCodes.Status409Conflict;
                title = "Conflict";
            }
            if (exception is UnauthorizedOperationException)
            {
                statusCode = StatusCodes.Status403Forbidden;
                title = "Unauthorized";
            }


            var ProblemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message,

            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(ProblemDetails);


            return true;
        }


        
    }
}

