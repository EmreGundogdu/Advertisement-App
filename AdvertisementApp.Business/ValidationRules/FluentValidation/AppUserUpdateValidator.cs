using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AppUserUpdateValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
