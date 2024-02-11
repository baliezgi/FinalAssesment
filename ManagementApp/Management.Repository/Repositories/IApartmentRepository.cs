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
        Task<Apartment> GetApartmentById(Guid id);
        Task<Apartment> GetApartmentByUserId(Guid userId);

        Task<Apartment> AddApartment(Apartment apartment);

        Task<Apartment> UpdateApartment(Guid id, Apartment apartment);
        Task<bool> DeleteApartment(Guid id);
    }
}
