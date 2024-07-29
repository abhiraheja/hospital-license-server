using LicenseServer.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseServer.Domain.Entities
{
    [Table("PatientTbl")]
    public class PatientEntity : EntityBase
    {
        public string Name { get; set; }
    }
}
