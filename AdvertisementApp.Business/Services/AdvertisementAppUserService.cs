using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entity;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        readonly IMapper _mapper;

        public AdvertisementAppUserService(IUnitOfWork unitOfWork, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }
        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _unitOfWork.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _unitOfWork.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _unitOfWork.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> errors = new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Daha önce başvurulan ilana tekrar başvuru yapılamaz", PropertyName = "" } };
                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConverToCustomValidationError());
        }
        public async Task<List<AdvertisementAppUserListDto>> GetListAsync(AdvertisementAppUserStatusType type)
        {
            var query = _unitOfWork.GetRepository<AdvertisementAppUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x => x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }
        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            //    var unchanged = await _unitOfWork.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            //    var changed = await _unitOfWork.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.Id == advertisementAppUserId);
            //    changed.AdvertisementAppUserStatusId = (int)type;
            //    _unitOfWork.GetRepository<AdvertisementAppUser>().Update(changed, unchanged);


            var query = _unitOfWork.GetRepository<AdvertisementAppUser>().GetQuery();
            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
