using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IGenericService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertiesementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertiesementListDto>>> GetActivesAsync();
    }
}
