using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        //public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
    }
}
