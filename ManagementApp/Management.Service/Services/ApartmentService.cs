using Management.Repository.Models;
using Management.Repository.Repositories;
using Management.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Services
{
    public class ApartmentService : IApartmentService
    {

        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<ResponseDto<List<ApartmentDto>>> GetApartment()
        {
            var apartments = await _apartmentRepository.GetApartment();
            var apartmentDtos = apartments.Select(p => new ApartmentDto
            {
                Id = p.Id,
                BlokNo = p.BlokNo,
                Floor = p.Floor,
                DoorNo = p.DoorNo,
                AppUserId = p.AppUserId


            }).ToList();

            return new ResponseDto<List<ApartmentDto>>
            {
                Data = apartmentDtos
            };
        }

        public async Task<ResponseDto<List<ApartmentDto>>> GetApartmentByUserId(Guid userId)
        {
            var apartment = await _apartmentRepository.GetApartmentByUserId(userId);
            return new ResponseDto<List<ApartmentDto>>
            {
                Data = new List<ApartmentDto>
                {
                    new ApartmentDto
                    {
                        Id = apartment.Id,
                        BlokNo = apartment.BlokNo,
                        Floor = apartment.Floor,
                        DoorNo = apartment.DoorNo,
                        AppUserId = apartment.AppUserId
                    }
                }
            };
            
        }

        public async Task<ResponseDto<ApartmentDto>> AddApartment(ApartmentDto apartmentDto)
        {
           var apartment = new Apartment // This is so wrong. I should use AutoMapper to map the ApartmentDto to Apartment
           {
                Id = apartmentDto.Id,
                BlokNo = apartmentDto.BlokNo,
                Floor = apartmentDto.Floor,
                DoorNo = apartmentDto.DoorNo,
                AppUserId = apartmentDto.AppUserId
            };

            return new ResponseDto<ApartmentDto>
            {
                Data = new ApartmentDto
                {
                    Id = apartment.Id,
                    BlokNo = apartment.BlokNo,
                    Floor = apartment.Floor,
                    DoorNo = apartment.DoorNo,
                    AppUserId = apartment.AppUserId
                }
            };

        }

        public async Task<ResponseDto<bool>> DeleteApartment(Guid id)
        {
            return new ResponseDto<bool>
            {
                Data = await _apartmentRepository.DeleteApartment(id)
            };
        }

        public async Task<ResponseDto<ApartmentDto>> GetById(Guid id)
        {
          var apartment = await _apartmentRepository.GetApartmentById(id);
            return new ResponseDto<ApartmentDto>
            {
                Data = new ApartmentDto
                {
                    Id = apartment.Id,
                    BlokNo = apartment.BlokNo,
                    Floor = apartment.Floor,
                    DoorNo = apartment.DoorNo,
                    AppUserId = apartment.AppUserId
                }
            };
        }

        public async Task<ResponseDto<ApartmentDto>> UpdateApartment(Guid id, ApartmentDto apartmentDto)
        {
           var apartment = new Apartment // This is so wrong. I should use AutoMapper to map the ApartmentDto to Apartment
           {
                Id = apartmentDto.Id,
                BlokNo = apartmentDto.BlokNo,
                Floor = apartmentDto.Floor,
                DoorNo = apartmentDto.DoorNo,
                AppUserId = apartmentDto.AppUserId
            };

            return new ResponseDto<ApartmentDto>
            {
                Data = new ApartmentDto
                {
                    Id = apartment.Id,
                    BlokNo = apartment.BlokNo,
                    Floor = apartment.Floor,
                    DoorNo = apartment.DoorNo,
                    AppUserId = apartment.AppUserId
                }
            };
        }
    }
}
