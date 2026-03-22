using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private readonly Stopwatch _stopwatch = new();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        context.HttpContext.Response.Headers.Append("X-Response-Time-Ms", _stopwatch.ElapsedMilliseconds.ToString());
    }
}