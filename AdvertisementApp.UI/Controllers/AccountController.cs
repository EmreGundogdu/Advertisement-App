using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.UI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        readonly IGenderService _genderService;
        readonly IValidator<UserCreateModel> _userCreateModelValidator;
        readonly IAppUserService _appUserService;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            ValidationResult result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                _appUserService.CreateAsycn(new )
                return View(model);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }
    }
}
