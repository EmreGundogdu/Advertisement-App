using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class ProvidedServiceService : GenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedServices>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {

        }
    }
}
