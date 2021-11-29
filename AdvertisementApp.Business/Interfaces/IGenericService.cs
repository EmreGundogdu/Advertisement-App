using AdvertisementApp.Common;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Dtos.ProvidedServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenericService<CreateDto, UpdateDto, ListDto> where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
    {
        Task<IResponse<CreateDto>> CreateAsycn(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
