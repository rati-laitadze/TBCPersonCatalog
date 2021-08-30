using AutoMapper;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Models;
using PersonCatalog.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<Person, PersonDTO>()
                 .ForMember(
                 dest => dest.Age,
                     opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()))
                 .ForMember(
                 dest => dest.Relatives,
                 opt => opt.MapFrom(src => src.RelativeTo))
                 .ForMember(dest => dest.ImageHttpPath,
                    opt => opt.MapFrom(src => ImageFilesHelpers.GetUploadedFilePhysicalPath(src.ImageFilename)));

        }
    }
}
