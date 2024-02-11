using Management.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Repository.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext _context;

        public ApartmentRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<Apartment>> GetApartment()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> GetApartmentById(Guid id)
        {
           return await _context.Apartments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Apartment> GetApartmentByUserId(Guid userId)
        {
            return await _context.Apartments.FirstOrDefaultAsync(x => x.AppUserId == userId);
        }

        public async Task<Apartment> AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return apartment;
           
        }

        public async Task<bool> DeleteApartment(Guid id)
        {
            var apartment = await GetApartmentById(id);
            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return true;
           
        }







        public async Task<Apartment> UpdateApartment(Guid id, Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}
