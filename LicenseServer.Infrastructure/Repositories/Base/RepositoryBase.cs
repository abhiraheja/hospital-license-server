using LicenseServer.Application.Interfaces.Base;
using LicenseServer.Domain;
using LicenseServer.Domain.Base;
using LicenseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServer.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }
            var entityContext = _context.Set<TEntity>();
            entityContext.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }
            var entityContext = _context.Set<TEntity>();
            entityContext.Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null");
            }
            var entityContext = _context.Set<TEntity>();
            entity.IsDeleted = true;
            entityContext.Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAsync()
        {

            var entityContext = _context.Set<TEntity>();
            return entityContext.Where(x => !x.IsDeleted).ToListAsync();
        }

        public Task<TEntity?> GetAsync(string id)
        {
            var entityContext = _context.Set<TEntity>();
            return entityContext.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
        }
    }
}
