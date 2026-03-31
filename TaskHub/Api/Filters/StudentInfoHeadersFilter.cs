using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для добавления заголовков с данными студента
/// </summary>
public class StudentInfoHeadersFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers.Append("X-Student-Name", "Khamitova Kseniia Andreevna");
        context.HttpContext.Response.Headers.Append("X-Student-Group", "RI-240932");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
    }
}