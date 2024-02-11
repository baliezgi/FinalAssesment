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

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(Guid id)
        {
            var result = await _paymentService.GetPaymentById(id);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        

      //  [Authorize(Roles ="yönetici")]
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> AddPayment(PaymentDto paymentDto)
        {
            var result = await _paymentService.AddPayment(paymentDto);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[Authorize(Roles="DaireSakini")]
        [HttpPut("{id}")]
       public async Task<ActionResult<PaymentDto>> UpdatePayment(Guid id, PaymentDto paymentDto)
        {
            var result = await _paymentService.UpdatePayment(id, paymentDto);
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDto>> Delete()
        {
            var result = await _paymentService.GetPayments();
            if (result.AnyError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }




    }
}
