using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class GenderService : GenericService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {

        }
    }
}
