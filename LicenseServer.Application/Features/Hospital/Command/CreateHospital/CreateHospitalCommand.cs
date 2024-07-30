using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.CreateHospital
{
    public class CreateHospitalCommand : IRequest<string>
    {
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
    }
}
