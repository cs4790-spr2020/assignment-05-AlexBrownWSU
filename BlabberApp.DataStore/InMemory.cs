using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlabberApp.DataStore
{
    public class InMemory<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationContext Context;
        private DbSet<T> _entities; 

        public InMemory(ApplicationContext context)
        {
            Context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            Context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetBySysId(string sysId)
        {
            if (sysId.Equals(""))
            {
                throw new ArgumentNullException("sysId");
            }

            return _entities.SingleOrDefault(s => s.getSysId() == sysId);
        }
    }
}
