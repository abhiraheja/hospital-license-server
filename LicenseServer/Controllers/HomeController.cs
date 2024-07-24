using LicenseServer.Domain;
using LicenseServer.Models.Hospital;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateHospital")]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalRequest request)
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
            await _context.SaveChangesAsync();
            return Ok("Created");
        }

        [HttpPut("UpdateHospital/{id}")]
        public async Task<IActionResult> UpdateHospital(string id, [FromBody] CreateHospitalRequest request)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                return NotFound("Hospital details not available");
            }

            if (string.IsNullOrEmpty(request.HospitalName))
            {
                return BadRequest("Hospital name is required");
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
            return Ok("Updated");

        }

        [HttpPatch("UpdateHospitalName/{id}/hospital/{name}")]
        public async Task<IActionResult> UpdateHospitalName(string id, string name)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                return NotFound("Hospital details not available");
            }

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Hospital name is required");
            }

            hospital.HospitalName = name;
            hospital.UpdatedBy = "AUTO";
            hospital.UpdatedDate = DateTimeOffset.Now;
            _context.Update(hospital);
            await _context.SaveChangesAsync();
            return Ok("Updated");

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteHospital(string id)
        {
            var hospital = await _context.HospitalEntities.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (hospital == null)
            {
                return NotFound("Hospital details not available");
            }
            _context.HospitalEntities.Remove(hospital);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        [HttpGet("GetHospitals")]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _context.HospitalEntities.Select(x => new HospitalListResponse
            {
                ContactName = x.ContactName,
                EmailAddress = x.EmailAddress,
                HospitalName = x.HospitalName,
                Id = x.Id,
                LicenseNumber = x.LicenseNumber,
                PhoneNumber = x.PhoneNumber,
            }).ToListAsync();
            return Ok(hospitals);
        }

        [HttpGet("GetHospital/{id}")]
        public async Task<IActionResult> GetHospitalById(string id)
        {
            var hospitals = await _context.HospitalEntities.Where(x => x.Id == id)
                    .Select(x => new HospitalListResponse
                    {
                        ContactName = x.ContactName,
                        EmailAddress = x.EmailAddress,
                        HospitalName = x.HospitalName,
                        Id = x.Id,
                        LicenseNumber = x.LicenseNumber,
                        PhoneNumber = x.PhoneNumber,
                    }).SingleOrDefaultAsync();
            return Ok(hospitals);
        }


    }
}
