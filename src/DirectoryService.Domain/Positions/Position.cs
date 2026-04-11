using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Positions;

/// <summary>
/// Позиция - это должности работников. Например разработчик, менеджер по продажам.
/// </summary>
public class Position
{
    public Guid Id { get; }

    public PositionName Name { get; private set; }

    public PositionDescription Description { get; private set; }

    public Activity Activity { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public Position(PositionName name, PositionDescription description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Activity = new Activity();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
}