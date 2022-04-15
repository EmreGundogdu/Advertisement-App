using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceListDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedServices>().ReverseMap();
        }
    }
}
