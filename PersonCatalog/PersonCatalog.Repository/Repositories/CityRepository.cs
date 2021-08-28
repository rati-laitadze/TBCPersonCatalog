using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Repository.Repositories
{
    public class CityRepository: RepositoryBase<City>, ICityRepository
    {
        public CityRepository(IUnitOfWork context) : base(context)
        {

        }
    }
}
