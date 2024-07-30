using AutoMapper;
using FluentValidation;
using LicenseServer.Application.Interfaces;
using LicenseServer.Domain.Entities;
using MediatR;

namespace LicenseServer.Application.Features.Hospital.Command.CreateHospital
{
    internal class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, string>
    {
        readonly IHospitalRepository _hospitalRepository;
        readonly IMapper _mapper;
        public CreateHospitalCommandHandler(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
          
            var entity = _mapper.Map<HospitalEntity>(request);
            entity.CreatedDate = DateTimeOffset.Now;
            entity.Id = Guid.NewGuid().ToString();
            entity.CreatedBy = "AUTO";
            await _hospitalRepository.AddAsync(entity);
            return entity.Id;
        }
    }
}
