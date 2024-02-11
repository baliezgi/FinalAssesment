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
        Task<ResponseDto<PaymentDto>> GetPaymentById(Guid id);
        Task<ResponseDto<PaymentDto>> AddPayment(PaymentDto paymentDto);
        Task<ResponseDto<PaymentDto>> UpdatePayment(Guid id, PaymentDto paymentDto);
        Task<ResponseDto<bool>> DeletePayment(Guid id);
        


    }
}
