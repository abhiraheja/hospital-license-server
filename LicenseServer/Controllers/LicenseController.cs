using AutoMapper;
using LicenseServer.Application.Features.Hospital.Command.CreateHospital;
using LicenseServer.Application.Features.Hospital.Command.DeleteHospital;
using LicenseServer.Application.Features.Hospital.Command.UpdateHospital;
using LicenseServer.Models.Hospital;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LicenseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;
        public LicenseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("CreateHospital")]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateHospitalCommand>(request);
                var res = await _mediator.Send(command);

                return Ok(res);
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
                //var hospital = await _hospitalRepository.GetAsync(id);
                //if (hospital == null)
                //{
                //    throw new Exception("Hospital details not available");
                //}

                //if (string.IsNullOrEmpty(request.HospitalName))
                //{
                //    throw new Exception("Hospital name is required");
                //}

                //hospital.PhoneNumber = request.PhoneNumber;
                //hospital.LicenseNumber = request.LicenseNumber;
                //hospital.HospitalName = request.HospitalName;
                //hospital.EmailAddress = request.EmailAddress;
                //hospital.ContactName = request.ContactName;
                //hospital.UpdatedBy = "AUTO";
                //hospital.UpdatedDate = DateTimeOffset.Now;
                //await _hospitalRepository.UpdateAsync(hospital);
                var command = _mapper.Map<UpdateHositalCommand>(request);
                command.Id = id;
                var response = await _mediator.Send(command);
                return Ok(response);
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
                //    var hospital = await _hospitalRepository.GetAsync(id);
                //    if (hospital == null)
                //    {
                //        throw new Exception("Hospital details not available");
                //    }
                //    await _hospitalRepository.DeleteAsync(hospital);
                var response = await _mediator.Send(new DeleteHospitalCommand(id));
                return Ok(response);
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
                //var result = (await _hospitalRepository.GetAsync()).Select(x => new HospitalListResponse
                //{
                //    ContactName = x.ContactName,
                //    EmailAddress = x.EmailAddress,
                //    HospitalName = x.HospitalName,
                //    Id = x.Id,
                //    LicenseNumber = x.LicenseNumber,
                //    PhoneNumber = x.PhoneNumber,
                //}).ToList();
                //return Ok(result);
                return Ok("");
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
                //var hospital = await _hospitalRepository.GetAsync(id);
                //if (hospital == null)
                //{
                //    throw new Exception("Hospital not found");
                //}
                //return Ok(new HospitalListResponse
                //{
                //    ContactName = hospital.ContactName,
                //    EmailAddress = hospital.EmailAddress,
                //    HospitalName = hospital.HospitalName,
                //    Id = hospital.Id,
                //    LicenseNumber = hospital.LicenseNumber,
                //    PhoneNumber = hospital.PhoneNumber,
                //});
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
