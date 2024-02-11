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
                BlokNo=p.BlokNo,
                Floor=p.Floor,
                DoorNo=p.DoorNo 


            }).ToList();

            return new ResponseDto<List<ApartmentDto>>
            {
                Data = apartmentDtos
            };
        }
        public async Task<ResponseDto<List<ApartmentDto>>> AddApartment(ApartmentDto apartmentDto)
        {
           var newApartment = new ApartmentDto
           {
                Id = Guid.NewGuid(),
                BlokNo = apartmentDto.BlokNo,
                Floor = apartmentDto.Floor,
                DoorNo = apartmentDto.DoorNo
            };
            return new ResponseDto<List<ApartmentDto>> { Data = new List<ApartmentDto> { newApartment } };
        }


    }
}
