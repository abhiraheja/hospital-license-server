using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.DeleteHospital
{
    public class DeleteHospitalCommand: IRequest<string>
    {
        public DeleteHospitalCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
