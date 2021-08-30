using PersonCatalog.Domain.Domains;
using PersonCatalog.Web.Models;
using System.Collections.Generic;

namespace PersonCatalog.Models
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string PersonalNumber { get; set; }
        public string ImageFilename { get; set; }
        public string ImageHttpPath { get; set; }
        public int Age { get; set; }
        public List<PhoneDTO> Phones { get; set; }
        public List<RelativeDTO> Relatives { get; set; }
        public CityDto City { get; set; }


    }
}
