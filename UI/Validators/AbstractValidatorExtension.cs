﻿using FluentValidation;
using UI.FormEntities.Account;

namespace UI.Validators
{
    public abstract class AbstractValidatorExtension<T> : AbstractValidator<T>
    {
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<T>.CreateWithOptions((T)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
            {
                return Array.Empty<string>();
            }
            
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}