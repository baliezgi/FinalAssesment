using Management.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Repository.Models;
using Management.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Management.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        #region GetPayments
        public async Task<ResponseDto<List<PaymentDto>>> GetPayments()
        {
            var payments = await _paymentRepository.GetPayments();
            var paymentDtos = payments.Select(p => new PaymentDto
            {

                Id = p.Id,
                //PaymentType = p.PaymentType,
                PaymentDate = p.PaymentDate,
                Amount = p.Amount
            }).ToList();

            return new ResponseDto<List<PaymentDto>>
            {
                Data = paymentDtos
            };
        } 
        #endregion

      
        

        public async Task<ResponseDto<PaymentDto>> GetPaymentById(Guid id)
        {
            var payment = await _paymentRepository.GetById(id);

            var paymentDto = new PaymentDto
            {
                Id = payment.Id,
                //PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount
            };

            return new ResponseDto<PaymentDto>
            {
                Data = paymentDto
            };
           
        }

       public async Task<ResponseDto<PaymentDto>> AddPayment(PaymentDto paymentDto)
        {
            var newPayment = new Payment
            {
                Id = Guid.NewGuid(),
                //PaymentType = paymentDto.PaymentType,
                PaymentDate = paymentDto.PaymentDate,
                Amount = paymentDto.Amount
            };
            await _paymentRepository.AddPayment(newPayment);
            return new ResponseDto<PaymentDto> { Data = paymentDto };
        }

        public async Task<ResponseDto<PaymentDto>> UpdatePayment(Guid id, PaymentDto paymentDto)
        {
            var payment = await _paymentRepository.GetById(id);
            payment.Amount = paymentDto.Amount;
            payment.PaymentDate = paymentDto.PaymentDate;
            await _paymentRepository.UpdatePayment(id, payment);
            return new ResponseDto<PaymentDto> { Data = paymentDto };
        }

        public async Task<ResponseDto<bool>> DeletePayment(Guid id)
        {
            return new ResponseDto<bool> { Data = await _paymentRepository.DeletePayment(id) };
        }
     



    }
}
