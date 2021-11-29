using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.Interface;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.Interfaces;
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
    public class GenericService<CreateDto, UpdateDto, ListDto, T> : IGenericService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUnitOfWork _unitOfWork;
        public GenericService(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<CreateDto>> CreateAsycn(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _unitOfWork.GetRepository<T>().CreateAsync(createdEntity);
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            return new Response<CreateDto>(dto, errors: new List<CustomValidationError>());
        }

        public Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
