using Microsoft.AspNetCore.Identity;

namespace Management.Repository.Models
{
    public class AppUser :IdentityUser<Guid> 
    {
        public string TcNo { get; set; }=default!;

        //User to payment: 1 to many
        public List<Payment>? Payment { get; set; }

        //User to apartment: 1 to 1
        public Apartment? Apartment { get; set; }

    }
}
