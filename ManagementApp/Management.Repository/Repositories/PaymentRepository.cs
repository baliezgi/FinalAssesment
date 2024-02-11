using Management.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        //public async Task<Guid> AddPayment(Payment payment)
        //{
        //    await _context.Payments.AddAsync(payment);
        //    await _context.SaveChangesAsync();
            
        //    return payment.Id;
        //} It does not work!

        public async Task<Payment> GetById(Guid id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePayment(Guid id, Payment payment)
        {
            if(!_context.Payments.Any(p => p.Id == id))
            {
                return null;
            }

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return payment;
            
        }

        public Task<bool> DeletePayment(Guid id)
        {
           var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            if(payment == null)
            {
                return Task.FromResult(false);
            }
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
