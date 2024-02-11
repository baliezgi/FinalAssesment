using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository.Models
{
    public class Apartment
    {
        public int Id { get; set; }=default!;
        public int BlokNo { get; set; }
        public int Floor { get; set; }
        public int DoorNo { get; set; }
        public string Status { get; set; }=default!;
        public string Type { get; set; }=default!;

        // User to apartment: 1 to 1
        public Guid AppUserId { get; set; }=default!;
        public AppUser? AppUser { get; set; }

        // Apartment to payment: 1 to many
        public List<Payment> Payments { get; set; } = default!;

    }
}
