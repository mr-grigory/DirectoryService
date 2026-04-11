using CSharpFunctionalExtensions;
using MrGrigory.MyUtils;

namespace DirectoryService.Domain.Positions;

public record PositionDescription
{
    public const short MAX_LENGTH = 1000;

    public string Value { get; }

    private PositionDescription(string value)
    {
        Value = value;
    }

    public static Result<PositionDescription, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return new PositionDescription(string.Empty);
        }

        if (value.Length > MAX_LENGTH)
        {
            return Error.Validation(
                "Position.Description",
                $"The description cannot be longer than {MAX_LENGTH} characters.",
                "Description");
        }

        return new PositionDescription(value);
    }
}