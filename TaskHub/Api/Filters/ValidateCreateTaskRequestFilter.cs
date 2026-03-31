using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для валидации запроса создания задачи
/// </summary>
public class ValidateCreateTaskRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        //Проверка тела запроса
        if (!context.ActionArguments.TryGetValue("request", out var requestObj) || requestObj is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var request = requestObj as CreateTaskRequest;
        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        //Проверка Title
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult("Название задачи не задано");
            return;
        }

        //Проверка UserId
        if (!context.ActionArguments.TryGetValue("userId", out var userIdObj) ||
            userIdObj is not Guid userId || userId == Guid.Empty)
        {
            context.Result = new BadRequestObjectResult("Идентификатор пользователя не задан");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}