using FluentValidation;
using ShoppingAPI.Entity.DTO.User;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class UserRegisterValidator:AbstractValidator<UserRequestDTO>
    {
        public UserRegisterValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage("E-posta Boş Olamaz");
            RuleFor(q => q.Phone).NotEmpty().WithMessage("Telefon Boş Olamaz");
            RuleFor(q => q.Adress).NotEmpty().WithMessage("Adres Boş Olamaz");

        }
    }
}
