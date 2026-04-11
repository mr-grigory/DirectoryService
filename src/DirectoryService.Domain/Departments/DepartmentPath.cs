using CSharpFunctionalExtensions;
using MrGrigory.MyUtils;

namespace DirectoryService.Domain.Departments;

public record DepartmentPath
{
    public Guid ParentId { get; }
    public string Path { get; }
    public short Depth { get; }
    
    private DepartmentPath(Guid parentId, string path)
    {
        ParentId = parentId;
        Path = path;
        Depth = (short)path.Split('.').Length;
    }

    public static Result<DepartmentPath, Error> Create(Guid parentId, string path)
    {
        if (parentId == Guid.Empty)
        {
            return Error.Validation(
                "Department.Path.ParentId",
                "Parent id must not be empty.",
                "ParentId");
        }

        if (string.IsNullOrEmpty(path))
        {
            return Error.Validation(
                "Department.Path.Path",
                "Path must not be empty.",
                "Path");
        }

        foreach (string s in path.Split('.'))
        {
            if (!DepartmentIdentifier.IsIdentifier(s))
            {
                return Error.Validation(
                    "Department.Path.Path",
                    $"identifier '{s}' is not valid.",
                    "Path");
            }
        }
        
        return new DepartmentPath(parentId, path);
    }
}