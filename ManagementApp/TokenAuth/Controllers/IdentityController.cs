using Management.Service.Dtos;
using Management.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenAuth.Services;

namespace TokenAuth.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IdentitiyService identitiyService, TokenService tokenService) : ControllerBase
    {

        [Authorize(Roles = "Yonetici")]
        [HttpPost("CreateUser")]
       public async Task<IActionResult> CreateUser(UserCreateDto user)
        {
            var result = await identitiyService.CreateUser(user);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }


        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken(TokenCreateDto tokenCreateDto)
        {
            var result = await tokenService.Create(tokenCreateDto);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }

       [Authorize(Roles = "Yonetici")]
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(RoleCreateRequestDto request)
        {
            var result = await identitiyService.AssignRole(request);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }


    }
}
