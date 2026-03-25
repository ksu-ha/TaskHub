namespace Logic.Tasks.Models;

/// <summary>
/// Модель задачи для слоя логики
/// </summary>
public sealed class TaskModel
{
    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название задачи
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Идентификатор пользователя, создавшего задачу
    /// </summary>
    public Guid CreatedByUserId { get; }

    /// <summary>
    /// Дата и время создания задачи в UTC
    /// </summary>
    public DateTimeOffset CreatedUtc { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public TaskModel(Guid id, string title, Guid createdByUserId, DateTimeOffset createdUtc)
    {
        Id = id;
        Title = title;
        CreatedByUserId = createdByUserId;
        CreatedUtc = createdUtc;
    }
}