
namespace LicenseServer.Domain.Base
{
    public interface ITable
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        string Id { get; set; }
        bool IsDeleted { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
    }
}