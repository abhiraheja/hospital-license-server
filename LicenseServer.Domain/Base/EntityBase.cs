using System.ComponentModel.DataAnnotations;

namespace LicenseServer.Domain.Base
{
    public abstract class EntityBase : ITable
    {
        [Key]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
