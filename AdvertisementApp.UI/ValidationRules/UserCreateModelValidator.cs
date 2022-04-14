using AdvertisementApp.UI.Models;
using FluentValidation;
using System;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        // [Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(X => X.Password).NotEmpty().WithMessage("Parola boş geçilemez").MinimumLength(3).WithMessage("Parola minimum 3 karkater olmalıdır.").Equal(x => x.ConfirmPassword).WithMessage("Parola ve Parola tekrarı alanları eşleşmiyor.");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı minimum 3 karakter olmalıdır.");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Kullanıcı adı isminiz ile aynı olamaz.").When(x => x.Username != null && x.Firstname != null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi boş geçilemez");
        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
