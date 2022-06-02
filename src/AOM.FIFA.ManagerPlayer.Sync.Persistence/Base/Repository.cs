using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Context;
using AOM.FIFA.ManagerPlayer.Sync.Application.Base.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected FIFASyncDbContext _fifaSyncDbContext;

        public Repository(FIFASyncDbContext fifaSyncDbContext)
        {
            this._fifaSyncDbContext = fifaSyncDbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._fifaSyncDbContext.
                        Set<T>().
                        ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this._fifaSyncDbContext.
                                Set<T>().
                                FindAsync(id);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            await _fifaSyncDbContext.
                    Set<T>().
                    AddAsync(entity);

            return Convert.ToBoolean(await _fifaSyncDbContext.SaveChangesAsync());
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _fifaSyncDbContext.
                Set<T>().
                Update(entity);

            return Convert.ToBoolean(await _fifaSyncDbContext.SaveChangesAsync());
        }

    }
}
