using Microsoft.EntityFrameworkCore;
using ProjectLeader.Data;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectLeader.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        private DbSet<TEntity> entities;
        string errorMessage = string.Empty;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<TEntity>();
        }

        public TEntity Get(Guid Id)
        {
            return _applicationDbContext.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _applicationDbContext.Set<TEntity>().AsEnumerable<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _applicationDbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _applicationDbContext.Set<TEntity>().Where(expression);
        }

        public void Update(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _applicationDbContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
