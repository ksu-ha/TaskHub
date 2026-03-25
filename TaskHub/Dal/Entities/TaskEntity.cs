namespace Dal.Entities;

/// <summary>
/// Задача
/// </summary>
public sealed class TaskEntity
{
    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор пользователя, создавшего задачу (внешний ключ)
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// Дата и время создания задачи в UTC
    /// </summary>
    public DateTimeOffset CreatedUtc { get; set; }
}