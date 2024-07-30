using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.UpdateHospital
{
    public class UpdateHositalCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
    }
}
