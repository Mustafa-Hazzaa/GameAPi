using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Exceptions;

public class GameExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GameExceptionHandler> _logger;

    public GameExceptionHandler(
        ILogger<GameExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var statusCode = exception switch
        {
            GameNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        if (exception is GameNotFoundException)
            {
                _logger.LogWarning(
                    "Game not found. Method: {Method}, Path: {Path}, StatusCode: {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode);
            }
            else
            {
                _logger.LogError(
                    exception,
                    "Unhandled exception. Method: {Method}, Path: {Path}, StatusCode: {StatusCode}",
                    context.Request.Method,
                    context.Request.Path,
                    statusCode);
            }



        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = exception switch
            {
                GameNotFoundException => "Game not found",
                _ => "An unexpected error occurred"
            },
            Detail = exception.Message
        };

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(
            problem,
            cancellationToken);

        return true;
    }
}