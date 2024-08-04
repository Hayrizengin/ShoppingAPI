using FluentValidation;
using ShoppingAPI.Entity.DTO.Login;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(q => q.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Adı Boş Olamaz");
        }
    }
}
