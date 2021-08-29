using PersonCatalog.Domain.Domains;

namespace PersonCatalog.Models
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public int Age { get; set; }
        
    }
}
