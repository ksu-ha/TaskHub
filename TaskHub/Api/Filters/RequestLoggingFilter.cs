using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для логирования запросов
/// </summary>
public class RequestLoggingFilter : IActionFilter
{
    private readonly ILogger<RequestLoggingFilter> _logger;

    public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger) => _logger = logger;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var httpMethod = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;

        _logger.LogInformation("[START] {Method} {Path}", httpMethod, path);

        context.HttpContext.Items["Stopwatch"] = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var stopwatch = context.HttpContext.Items["Stopwatch"] as Stopwatch;
        stopwatch?.Stop();

        var elapsedMs = stopwatch?.ElapsedMilliseconds ?? 0;
        var statusCode = context.HttpContext.Response.StatusCode;
        var httpMethod = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;

        _logger.LogInformation("[END] {Method} {Path} Status: {StatusCode}, Time: {ElapsedMs}ms",
            httpMethod, path, statusCode, elapsedMs);
    }
}