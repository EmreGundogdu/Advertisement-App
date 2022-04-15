using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenderService : IGenericService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
