using AdvertisementApp.Common;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConverToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var item in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName
                });
            }
            return errors;
        }
    }
}
