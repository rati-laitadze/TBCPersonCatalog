using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonCatalog.Repository.Repositories
{
    public class PersonRepository: RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork context) : base(context)
        {
        }

        public IQueryable<Person> SearchForPeople(PeopleResourceParameters parameters)
        {
            var retValue = Set().AsQueryable();
            if (parameters == null)
            {
                return retValue;
            }
            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                retValue = retValue.Where(item => item.Name.Contains(parameters.Name));
            }
            if (!string.IsNullOrWhiteSpace(parameters.Surname))
            {
                retValue = retValue.Where(item => item.Surname.Contains(parameters.Surname));
            }
            if (!string.IsNullOrWhiteSpace(parameters.PersonalNumber))
            {
                retValue = retValue.Where(item => item.PersonalNumber.Contains(parameters.PersonalNumber));
            }
            if (parameters.PageNumber == 0 || parameters.ItemPerPage == 0)
            {
                return retValue;
            }
            retValue = retValue.Skip((parameters.PageNumber - 1) * parameters.ItemPerPage).Take(parameters.ItemPerPage);

            return retValue;
        }
    }
}
