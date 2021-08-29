using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IRepositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IQueryable<Person> SearchForPeople(PeopleResourceParameters parameters);
    }
}
