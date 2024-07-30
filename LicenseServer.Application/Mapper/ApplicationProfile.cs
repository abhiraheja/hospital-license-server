using AutoMapper;
using LicenseServer.Application.Features.Hospital.Command.CreateHospital;
using LicenseServer.Domain.Entities;
using LicenseServer.Models.Hospital;

namespace LicenseServer.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateHospitalRequest, CreateHospitalCommand>();
            CreateMap<CreateHospitalCommand, HospitalEntity>();
        }
    }
}
