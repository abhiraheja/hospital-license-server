using LicenseServer.Application.Interfaces;
using LicenseServer.Domain;
using LicenseServer.Domain.Entities;
using LicenseServer.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServer.Infrastructure.Repositories
{
    public class PatientRepository : RepositoryBase<PatientEntity>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
