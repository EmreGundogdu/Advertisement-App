using AdvertisementApp.Business.Interfaces;
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
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createtoValidator, updateDtoValidator, unitOfWork)
        {

        }
    }
}
