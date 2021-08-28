using Microsoft.EntityFrameworkCore;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Repository.Context;
using System;
using System.Collections.Generic;

namespace PersonCatalog.Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PersonDbContext _context;

        public IUnitOfWork Context
        {
            get { return _context; }
        }

        public RepositoryBase(IUnitOfWork context) : this(context as PersonDbContext) { }

        public RepositoryBase(PersonDbContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)}");

            _context = context;
        }

        public virtual T Fetch(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> Set()
        {
            return _context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                _context.Set<T>().Add(entity);
            }
        }


        public virtual void Delete(int id)
        {
            Delete(Fetch(id));
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            Context.Commit();
        }
    }
}
