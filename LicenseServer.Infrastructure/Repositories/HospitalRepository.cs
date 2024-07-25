using Azure.Core;
using LicenseServer.Application.Interfaces;
using LicenseServer.Domain;
using LicenseServer.Models.Hospital;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Infrastructure.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        readonly ApplicationDbContext _context;
        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<int> CreateHospital(CreateHospitalRequest request)
        {
            _context.HospitalEntities.Add(new Domain.Entities.HospitalEntity
            {
                ContactName = request.ContactName,
                CreatedBy = "AUTO",
                CreatedDate = DateTimeOffset.Now,
                EmailAddress = request.EmailAddress,
                HospitalName = request.HospitalName,
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                LicenseNumber = request.LicenseNumber,
                PhoneNumber = request.PhoneNumber,
            });
            return _context.SaveChangesAsync();

        }

        public async Task UpdateHospital(string id, CreateHospitalRequest request)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                throw new Exception("Hospital details not available");
            }

            if (string.IsNullOrEmpty(request.HospitalName))
            {
                throw new Exception("Hospital name is required");
            }

            hospital.PhoneNumber = request.PhoneNumber;
            hospital.LicenseNumber = request.LicenseNumber;
            hospital.HospitalName = request.HospitalName;
            hospital.EmailAddress = request.EmailAddress;
            hospital.ContactName = request.ContactName;
            hospital.UpdatedBy = "AUTO";
            hospital.UpdatedDate = DateTimeOffset.Now;
            _context.Update(hospital);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateHospitalName(string id, string name)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                throw new Exception("Hospital details not available");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Hospital name is required");
            }

            hospital.HospitalName = name;
            hospital.UpdatedBy = "AUTO";
            hospital.UpdatedDate = DateTimeOffset.Now;
            _context.Update(hospital);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteHospital(string id)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                throw new Exception("Hospital details not available");
            }
            _context.HospitalEntities.Remove(hospital);
            await _context.SaveChangesAsync();
        }

        public Task<List<HospitalListResponse>> GetHospitals()
        {
            return _context.HospitalEntities.Select(x => new HospitalListResponse
            {
                ContactName = x.ContactName,
                EmailAddress = x.EmailAddress,
                HospitalName = x.HospitalName,
                Id = x.Id,
                LicenseNumber = x.LicenseNumber,
                PhoneNumber = x.PhoneNumber,
            }).ToListAsync();
        }

        public Task<HospitalListResponse?> GetHospitalById(string id)
        {
            return _context.HospitalEntities.Where(x => x.Id == id)
                     .Select(x => new HospitalListResponse
                     {
                         ContactName = x.ContactName,
                         EmailAddress = x.EmailAddress,
                         HospitalName = x.HospitalName,
                         Id = x.Id,
                         LicenseNumber = x.LicenseNumber,
                         PhoneNumber = x.PhoneNumber,
                     }).SingleOrDefaultAsync();
        }
    }
}
