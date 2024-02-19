using Management.Service.Dtos;
using Management.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuth.Controllers
{
    [Authorize(Roles = "Yonetici")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {

        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ApartmentDto>>>> GetApartment()
        {
            var result = await _apartmentService.GetApartment();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ResponseDto<List<ApartmentDto>>>> GetApartmentsByUserId(Guid userId)
        {
            var response = await _apartmentService.GetApartmentByUserId(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ApartmentDto>>> AddApartment(ApartmentDto apartmentDto)
        {
            var response = await _apartmentService.AddApartment(apartmentDto);
            return Ok(response);
        }


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ResponseDto<bool>>> DeleteApartment(Guid id)
        //{
        //    var response = await _apartmentService.DeleteApartment(id);
        //    return Ok(response);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ApartmentDto>>> GetApartmentById(Guid id)
        {
            var response = await _apartmentService.GetById(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ApartmentDto>>> UpdateApartment(Guid id, ApartmentDto apartmentDto)
        {
            var response = await _apartmentService.UpdateApartment(id, apartmentDto);
            return Ok(response);
        }







    }




}

