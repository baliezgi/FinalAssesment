using Management.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Services
{
    public interface IPaymentService
    {
        Task<ResponseDto<List<PaymentDto>>> GetPayments();
    }
}
