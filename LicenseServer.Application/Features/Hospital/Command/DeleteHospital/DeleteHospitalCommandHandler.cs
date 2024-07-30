using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.DeleteHospital
{
    public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, string>
    {
        public Task<string> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
