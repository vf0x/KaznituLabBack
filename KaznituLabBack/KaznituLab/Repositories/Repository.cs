using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFData.Context;
using KaznituLab.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaznituLab.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly KaznituLabContext _context;
        public Repository(KaznituLabContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveById(int Id)
        {
            var res = _context.Set<TEntity>().Find(Id);
            _context.Set<TEntity>().Remove(res);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public void InsertOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            //_context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }
        public void InsertOrUpdateRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().UpdateRange(entity);
            //_context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
        }
    }
}
