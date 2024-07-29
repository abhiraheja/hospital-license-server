using LicenseServer.Application.Interfaces.Base;
using LicenseServer.Domain.Entities;

namespace LicenseServer.Application.Interfaces
{
    public interface IPatientRepository : IRepositoryBase<PatientEntity>
    {
    }
}
