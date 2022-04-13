using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenderService : IGenericService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
