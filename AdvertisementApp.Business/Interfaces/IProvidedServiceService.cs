using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IGenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedServices>
    {
    }
}
