using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IGenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedServices>
    {
    }
}
