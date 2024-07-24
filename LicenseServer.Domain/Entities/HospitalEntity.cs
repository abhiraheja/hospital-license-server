using LicenseServer.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenseServer.Domain.Entities
{
    [Table("HospitalTbl")]
    public class HospitalEntity : EntityBase
    {
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }

    }
}
