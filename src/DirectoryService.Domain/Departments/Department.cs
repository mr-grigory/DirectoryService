using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Departments;

/// <summary>
/// Подразделение - это какая-то часть компании, её отдел, которая отвечает за свои функции. Например отдел кадров, команда поддержки, филиал в каком-то городе.
/// </summary>
public class Department
{
    public Guid Id { get; }

    public DepartmentName Name { get; private set; }

    public DepartmentIdentifier Identifier { get; private set; }

    public DepartmentPath? Path { get; private set; }

    public Activity Activity { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }


    public Department(DepartmentName name, DepartmentIdentifier identifier, Guid? parentId, DepartmentPath? path)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        Path = path;
        Activity = new Activity();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
}