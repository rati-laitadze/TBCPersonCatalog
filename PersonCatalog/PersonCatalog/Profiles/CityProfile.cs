using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Models;

namespace PersonCatalog.Web.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
