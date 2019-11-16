using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class EfBaseRepository<TEntity> : IDisposable, IEfBaseRepository<TEntity> where TEntity : class
    {
        private readonly IEfBaseRepository<TEntity> _base_service;

        public EfBaseRepository(IEfBaseRepository<TEntity> BaseService)
        {
            _base_service = BaseService;
        }

        public void Add(TEntity obj)
        {
            _base_service.Add(obj);
        }

        public void Dispose()
        {
            _base_service.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _base_service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _base_service.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _base_service.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _base_service.Update(obj);
        }
    }
}