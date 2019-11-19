using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class EfBaseRepository<TEntity> : IEfBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ProjMoviesContext _base_context;

        public EfBaseRepository(ProjMoviesContext baseContext)
        {
            _base_context = baseContext;
        }

        public async Task Add(TEntity obj)
        {
            await _base_context.Set<TEntity>().AddAsync(obj);
            await _base_context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TEntity> obj)
        {
            await _base_context.Set<TEntity>().AddRangeAsync(obj);
            await _base_context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _base_context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _base_context.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity obj)
        {
            _base_context.Entry(obj).State = EntityState.Modified;
            await _base_context.SaveChangesAsync();
        }

        public async Task Remove(TEntity obj)
        {
            _base_context.Set<TEntity>().Remove(obj);
            await _base_context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> obj)
        {
            _base_context.Set<TEntity>().RemoveRange(obj);
            await _base_context.SaveChangesAsync();
        }
    }
}