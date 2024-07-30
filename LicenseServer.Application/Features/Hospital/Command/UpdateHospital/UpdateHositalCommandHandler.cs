using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.UpdateHospital
{
    internal class UpdateHositalCommandHandler : IRequestHandler<UpdateHositalCommand, string>
    {
        public Task<string> Handle(UpdateHositalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
