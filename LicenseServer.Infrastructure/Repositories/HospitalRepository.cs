using LicenseServer.Application.Interfaces;
using LicenseServer.Domain;
using LicenseServer.Domain.Entities;
using LicenseServer.Infrastructure.Repositories.Base;

namespace LicenseServer.Infrastructure.Repositories
{
    public class HospitalRepository : RepositoryBase<HospitalEntity>, IHospitalRepository
    {
        public HospitalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
