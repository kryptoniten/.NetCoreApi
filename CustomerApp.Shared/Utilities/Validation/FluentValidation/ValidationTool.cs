using System.Collections.Generic;
using FluentValidation;
using CustomerApp.Shared.Entities.Concrete;
using CustomerApp.Shared.Utilities.Results.Abstract;
using CustomerApp.Shared.Utilities.Results.ComplexTypes;
using CustomerApp.Shared.Utilities.Results.Concrete;

namespace MakasApp.Shared.Utilities.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static IResult Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                IList<ValidationError> validationErrors = new List<ValidationError>();
                foreach (var error in result.Errors)
                {
                    validationErrors.Add(new ValidationError
                    {
                        PropertyName = error.PropertyName,
                        Message = error.ErrorMessage
                    });
                }

                return new Result(ResultStatus.Error, $"Bir veya daha fazla validasyon hatasına rastlandı.",
                    validationErrors);
            }

            return new Result(ResultStatus.Success);
        }
    }
}