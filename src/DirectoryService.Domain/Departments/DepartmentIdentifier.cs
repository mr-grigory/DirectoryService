using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using MrGrigory.MyUtils;

namespace DirectoryService.Domain.Departments;

public record DepartmentIdentifier
{
    public const int MaxLength = 150;
    public const int MinLength = 3;
    public string Value { get; private set; }

    private DepartmentIdentifier(string value)
    {
        Value = value;
    }
    
    private static bool VerifyLatin(string text)
    {
        return Regex.IsMatch(text, @"^[A-Za-z0-9_-]+$");
    }

    public static bool IsIdentifier(string value) => VerifyLatin(value);

    public static Result<DepartmentIdentifier, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return Error.Validation(
                "department.identifier",
                "min length of identifier is 3 characters",
                "Identifier");
        }

        if (value.Length > MaxLength || value.Length < MinLength)
        {
            return Error.Validation(
                "department.identifier",
                $"Identifier  must be between {MinLength} and {MaxLength} characters",
                "Identifier");
        }

        if (!VerifyLatin(value))
        {
            return Error.Validation(
                "department.identifier",
                $"Identifier can contain only Latin characters, '_' and '-'",
                "Identifier");
        }

        return new DepartmentIdentifier(value);
    }
}