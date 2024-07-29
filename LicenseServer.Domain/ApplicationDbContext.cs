using LicenseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<HospitalEntity> HospitalEntities { get; set; }
        public DbSet<PatientEntity> PatientEntities { get; set; }
    }
}
