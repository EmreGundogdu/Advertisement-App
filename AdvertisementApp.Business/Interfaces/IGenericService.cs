using AdvertisementApp.Common;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenericService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsycn(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
