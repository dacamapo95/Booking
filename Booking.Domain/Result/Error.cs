namespace Booking.Domain.Result;

public class Error
{
    public string Code { get; }

    public string Message { get; }

    public ErrorTypeEnum ErrorType { get; }

    public static readonly Error None = new(string.Empty);

    public Error(string message)
    {
        Message = message;
        ErrorType = ErrorTypeEnum.Error;
    }

    public Error(string code, string description)
    {
        Code = code;
        Message = description;
        ErrorType = ErrorTypeEnum.Validation;
    }

    private Error(string message, ErrorTypeEnum errorType)
    {
        ErrorType = errorType;
        Message = message;
    }

    public static Error BadRequest(string message) =>
        new Error(message, ErrorTypeEnum.BadRequest);

    public static Error NotFound(string message) =>
        new Error(message, ErrorTypeEnum.NotFound);

    public static Error Validation(string message) =>
        new Error(message, ErrorTypeEnum.Validation);

    public static Error Unauthorized(string message) =>
        new Error(message, ErrorTypeEnum.Unauthorized);

    public static Error InternalServerError(string message) =>
        new Error(message, ErrorTypeEnum.Error);
}

public enum ErrorTypeEnum
{
    BadRequest = 1,
    NotFound = 2,
    Validation = 3,
    Unauthorized = 4,
    Error = 5   
}