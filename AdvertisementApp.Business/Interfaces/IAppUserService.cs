using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
    }
}
