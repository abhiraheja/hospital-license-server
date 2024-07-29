using LicenseServer.Domain.Base;

namespace LicenseServer.Application.Interfaces.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAsync();
        Task<TEntity?> GetAsync(string id);
    }
}
