using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("All Payments");
        }

        [Authorize(Roles ="yönetici")]
        [HttpPost]
        public IActionResult Add()
        {
            return Ok("Payment added");
        }

        [Authorize(Roles="DaireSakini")]
        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Payment updated");
        }


    }
}
