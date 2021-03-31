using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); //doğrulama contexti oluştur.
            //ProductValidator productValidator = new ProductValidator(); //bir sürü if yerine FluentValidation kullanıyoruz.
            var result = validator.Validate(context);
            if (!result.IsValid) //! = değil ise
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
