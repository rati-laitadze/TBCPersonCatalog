using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IUnitOfWork Context { get; }

        void Add(T entity);

        T Fetch(int id);

        IEnumerable<T> Set();

        void Save();

        void Delete(T entity);

        void Delete(int id);

    }
}
