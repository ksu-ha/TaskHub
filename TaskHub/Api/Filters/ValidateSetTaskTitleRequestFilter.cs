using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для валидации запроса изменения названия задачи
/// </summary>
public class ValidateSetTaskTitleRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("request", out var requestObj) || requestObj is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var request = requestObj as SetTaskTitleRequest;
        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}