using Dal.Entities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с задачами
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Создать задачу
    /// </summary>
    /// <param name="title">Название задачи</param>
    /// <param name="userId">Идентификатор пользователя, создавшего задачу</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Созданная задача</returns>
    Task<TaskEntity> CreateTaskAsync(string title, Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все задачи
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список задач</returns>
    Task<IReadOnlyCollection<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить задачу по id
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Задача или null, если задача не найдена</returns>
    Task<TaskEntity?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить название задачи
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="title">Новое название задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить задачу по id
    /// </summary>
    /// <param name="taskId">Идентификатор задачи</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true, если задача удалена, иначе false</returns>
    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить все
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}