using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementService : GenericService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertiesementListDto, Advertisement>, IAdvertisementService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertiesementListDto>>> GetActivesAsync()
        {
            var data = await _unitOfWork.GetRepository<Advertisement>().GetAllAsync(x => x.Status == true, x => x.CreatedTime, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertiesementListDto>>(data);
            return new Response<List<AdvertiesementListDto>>(ResponseType.Success, dto);
        }
    }
}
