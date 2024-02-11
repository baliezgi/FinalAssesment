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
    }
}
