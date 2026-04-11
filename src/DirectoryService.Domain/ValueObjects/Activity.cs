namespace DirectoryService.Domain.ValueObjects;

public record Activity
{
    public bool IsActive { get; }
    public bool IsDeleted { get; }
    public DateTime UpdatedAt { get; }

    public Activity(bool isActive = true)
    {
        IsActive = isActive;
        IsDeleted = !isActive;
        UpdatedAt = DateTime.UtcNow;
    }
}