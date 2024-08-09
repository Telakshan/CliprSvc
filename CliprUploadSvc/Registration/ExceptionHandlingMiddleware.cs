using Clipr.Application.Exceptions;

namespace Clipr.API.Registration;

internal class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (UnauthorizedAccessException)
        {
            _logger.LogError("Exception occurred: {Message}", "Unauthorized access.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { Success = false, Message = "Unauthorized access." });
        }

        catch (ValidationException ex)
        {
            _logger.LogError(
                ex, "Exception occurred: {Message}", ex.Message);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { Success = false, ex.Message });
        }

        catch (NotFoundException ex)
        {
            _logger.LogError(
                ex, "Exception occurred: {Message}", ex.Message);
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new { Success = false, ex.Message });
        }

        catch (Exception ex)
        {
            // Handle other unhandled exceptions
            _logger.LogError(
                ex, "Exception occurred: {Message}", ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { Success = false, Message = "An unhandles exception occurred while processing your request." });
        }
    }
}
