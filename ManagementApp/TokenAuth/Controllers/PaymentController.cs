using Management.Service.Dtos;
using Management.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuth.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> GetPayments()
        {
            var result = await _paymentService.GetPayments();
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        

      //  [Authorize(Roles ="yönetici")]
        [HttpPost]
        public IActionResult Add()
        {
            return Ok("Payment added");
        }

        //[Authorize(Roles="DaireSakini")]
        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Payment updated");
        }


    }
}
