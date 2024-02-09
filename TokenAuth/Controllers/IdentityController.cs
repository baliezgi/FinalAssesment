using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenAuth.Models;
using Microsoft.AspNetCore.Identity;
using TokenAuth.Dtos;
using TokenAuth.Services;

namespace TokenAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IdentitiyService identitiyService) : ControllerBase
    {


       [HttpPost("Create")]
       public async Task<IActionResult> CreateUser(UserCreateDto user)
        {
            var result = await identitiyService.CreateUser(user);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Created("", result);
        }
        


    }
}
