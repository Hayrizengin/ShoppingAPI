using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using ShoppingAPI.Helper.CustomException;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    //Validation işlemlerimi merkezi bir hale getireceğim
    public static class ValidationHelper
    {
        public static void Validate(Type type, object[] items)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Validator Geçerli Bir Tip Değildir.");
            }
            var validator = (IValidator)Activator.CreateInstance(type); // Reflection tarafı

            foreach (var item in items)
            {
                if (validator.CanValidateInstancesOfType(item.GetType()))
                {
                    var result = validator.Validate(new ValidationContext<object>(item));
                    List<string> ValidationMessages = new List<string>();   

                    foreach (var error in result.Errors)
                    {
                        ValidationMessages.Add(error.ErrorMessage);
                    }

                    if (!result.IsValid)
                    {
                        throw new FieldValidationException(ValidationMessages);
                    }
                }
            }
        }
    }
}
