using LicenseServer.Application.Interfaces;
using LicenseServer.Domain;
using LicenseServer.Infrastructure.Repositories;
using LicenseServer.Models.Hospital;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        readonly IHospitalRepository _hospitalRepository;
        public LicenseController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [HttpPost("CreateHospital")]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalRequest request)
        {
            try
            {
                await _hospitalRepository.AddAsync(new Domain.Entities.HospitalEntity
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
                return Ok("Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateHospital/{id}")]
        public async Task<IActionResult> UpdateHospital(string id, [FromBody] CreateHospitalRequest request)
        {
            try
            {
                var hospital = await _hospitalRepository.GetAsync(id);
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
                await _hospitalRepository.UpdateAsync(hospital);
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateHospitalName/{id}/hospital/{name}")]
        public async Task<IActionResult> UpdateHospitalName(string id, string name)
        {
            try
            {
                var hospital = await _hospitalRepository.GetAsync(id);
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
                await _hospitalRepository.UpdateAsync(hospital);
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteHospital(string id)
        {
            try
            {
                var hospital = await _hospitalRepository.GetAsync(id);
                if (hospital == null)
                {
                    throw new Exception("Hospital details not available");
                }
                await _hospitalRepository.DeleteAsync(hospital);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHospitals")]
        public async Task<IActionResult> GetHospitals()
        {
            try
            {
                var result = (await _hospitalRepository.GetAsync()).Select(x => new HospitalListResponse
                {
                    ContactName = x.ContactName,
                    EmailAddress = x.EmailAddress,
                    HospitalName = x.HospitalName,
                    Id = x.Id,
                    LicenseNumber = x.LicenseNumber,
                    PhoneNumber = x.PhoneNumber,
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHospital/{id}")]
        public async Task<IActionResult> GetHospitalById(string id)
        {
            try
            {
                var hospital = await _hospitalRepository.GetAsync(id);
                if (hospital == null)
                {
                    throw new Exception("Hospital not found");
                }
                return Ok(new HospitalListResponse
                {
                    ContactName = hospital.ContactName,
                    EmailAddress = hospital.EmailAddress,
                    HospitalName = hospital.HospitalName,
                    Id = hospital.Id,
                    LicenseNumber = hospital.LicenseNumber,
                    PhoneNumber = hospital.PhoneNumber,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
