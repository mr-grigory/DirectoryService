using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using MrGrigory.MyUtils;

namespace DirectoryService.Domain.Departments;

public record DepartmentName
{
    public const byte MAX_LENGTH = 150;
    public const byte MIN_LENGTH = 3;
    public string Value { get; private set; }

    private DepartmentName(string value)
    {
        Value = value;
    }
    
    private static bool VerifyLatin(string text)
    {
        return Regex.IsMatch(text, @"^[A-Za-z0-9_-]+$");
    }

    public static Result<DepartmentName, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return Error.Validation(
                "department.name",
                "min length of name is 3 characters",
                "Name");
        }

        if (value.Length > MAX_LENGTH || value.Length < MIN_LENGTH)
        {
            return Error.Validation(
                "department.name",
                $"Name  must be between {MIN_LENGTH} and {MAX_LENGTH} characters",
                "Name");
        }
        
        if (!VerifyLatin(value))
        {
            return Error.Validation(
                "department.name",
                $"Name can contain only Latin characters, '_' and '-'",
                "Name");
        }

        return new DepartmentName(value);
    }
}