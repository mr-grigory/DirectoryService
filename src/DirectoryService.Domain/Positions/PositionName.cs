using CSharpFunctionalExtensions;
using MrGrigory.MyUtils;

namespace DirectoryService.Domain.Positions;

public record PositionName
{
    public const byte MAX_LENGTH = 120;
    public const byte MIN_LENGTH = 3;

    public string Value { get; }

    private PositionName(string value) => Value = value;

    public static Result<PositionName, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return Error.Validation(
                "Position.Name",
                "The position name cannot be null or empty.",
                "PositionName");
        }

        if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return Error.Validation(
                "Position.Name",
                $"Position name must be between {MIN_LENGTH} and {MAX_LENGTH} characters long",
                "PositionName");
        }

        return new PositionName(value);
    }
}