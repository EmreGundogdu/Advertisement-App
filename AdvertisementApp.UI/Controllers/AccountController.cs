using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        readonly IGenderService _genderService;
        readonly IValidator<UserCreateModel> _userCreateModelValidator;
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
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
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RolType.Member);
                return this.ResponseRedirectoAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                var claims = new List<Claim>();
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }
    }
}
