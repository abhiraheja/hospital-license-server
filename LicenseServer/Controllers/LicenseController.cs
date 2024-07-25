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
                await _hospitalRepository.CreateHospital(request);
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
                await _hospitalRepository.UpdateHospital(id, request);
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
                await _hospitalRepository.UpdateHospitalName(id, name);
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
                await _hospitalRepository.DeleteHospital(id);
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
                var list = await _hospitalRepository.GetHospitals();
                return Ok(list);
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
                var hospitals = await _hospitalRepository.GetHospitalById(id);
                return Ok(hospitals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
