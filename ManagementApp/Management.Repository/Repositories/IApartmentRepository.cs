using Management.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository.Repositories
{
    public interface IApartmentRepository
    {
        Task<List<Apartment>> GetApartment();
        Task<Guid> AddApartment(Apartment apartment);
    }
}
