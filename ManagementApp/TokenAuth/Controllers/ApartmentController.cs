using Management.Service.Dtos;
using Management.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuth.Controllers
{
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
        public async Task<ActionResult<List<ApartmentDto>>> GetApartment()
        {
            var result = await _apartmentService.GetApartment();
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ApartmentDto>>> AddApartment(ApartmentDto apartmentDto)
        {
            var result = await _apartmentService.AddApartment(apartmentDto);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<List<ApartmentDto>>> UpdateApartment(ApartmentDto apartmentDto)
        {
            
            return Ok();
        }

        


    }




}

