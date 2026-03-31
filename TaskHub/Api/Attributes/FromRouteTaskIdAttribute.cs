using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Attributes;

public class FromRouteTaskIdAttribute : ModelBinderAttribute
{
    public FromRouteTaskIdAttribute()
    {
        BindingSource = BindingSource.Path;
        BinderType = typeof(TaskIdModelBinder);
    }
}

public class TaskIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueResult == ValueProviderResult.None)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи не задан");
            return Task.CompletedTask;
        }

        var rawValue = valueResult.FirstValue;
        if (string.IsNullOrEmpty(rawValue))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи не задан");
            return Task.CompletedTask;
        }

        if (!Guid.TryParse(rawValue, out var guidValue))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи имеет некорректный формат");
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(guidValue);
        return Task.CompletedTask;
    }
}