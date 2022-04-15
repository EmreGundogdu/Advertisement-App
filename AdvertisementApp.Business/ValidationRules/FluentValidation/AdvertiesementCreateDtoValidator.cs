using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AdvertiesementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertiesementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
