using Logic.Tasks.Models;

namespace Logic.Tasks.Services.Interfaces;

/// <summary>
/// Сервис для работы с задачами
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Создать задачу
    /// </summary>
    /// <param name="title">Название задачи</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель задачи</returns>
    Task<TaskModel> CreateTaskAsync(string title, Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все задачи
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список задач</returns>
    Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель задачи или null, если задача не найдена</returns>
    Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Изменить название задачи
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="title">Новое название задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true, если задача удалена, иначе false</returns>
    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}