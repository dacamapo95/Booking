using FluentValidation.Results;

namespace Booking.Application.Core.Common;

public static class FluentValidationExtensions
{
    public static Domain.Result.Error[] ToResultValidationErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Where(validation => validation is not null)
            .Select(validationFailure => 
                new Domain.Result.Error( validationFailure.PropertyName, validationFailure.ErrorMessage))
            .ToArray();
    }
}