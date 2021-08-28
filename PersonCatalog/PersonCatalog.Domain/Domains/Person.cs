using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PersonCatalog.Domain.Domains
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public string ImageFilename { get; set; }

        public virtual ICollection<PhoneNumber> Phones { get; set; }
        public virtual ICollection<Relation> RelativeTo { get; set; }
        public virtual ICollection<Relation> RelativeFrom { get; set; }

    }
}
