using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AppUserService : GenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly IValidator<AppUserCreateDto> _createDtoValidator;
        readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _unitOfWork.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _unitOfWork.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

                //await _unitOfWork.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                //{
                //    AppRoleId = roleId,
                //    AppUserId = 
                //});
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConverToCustomValidationError());
        }
        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _unitOfWork.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user is not null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatalı");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }
    }
}
