using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    interface IProvidedServiceService : IGenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedServices>
    {
    }
}
