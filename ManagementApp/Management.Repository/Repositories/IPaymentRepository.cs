using Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPayments();
        //Task<Guid> AddPayment(Payment payment);
        Task<Payment> GetById(Guid id);
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Guid id,Payment payment);
        Task<bool> DeletePayment(Guid id);

    }
}
