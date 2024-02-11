using Management.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Services
{
    public interface IApartmentService
    {

        Task<ResponseDto<List<ApartmentDto>>> GetApartment();
        Task<ResponseDto<List<ApartmentDto>>> GetApartmentByUserId(Guid userId);
        Task<ResponseDto<ApartmentDto>> GetById(Guid id);
        Task<ResponseDto<ApartmentDto>> AddApartment(ApartmentDto apartmentDto);
        Task<ResponseDto<ApartmentDto>> UpdateApartment(Guid id, ApartmentDto apartmentDto);
        Task<ResponseDto<bool>> DeleteApartment(Guid id);

    }
}
