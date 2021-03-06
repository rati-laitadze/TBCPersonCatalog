using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonCatalog.Domain.Domains
{
    public class PhoneNumber
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50), MinLength(4)]
        public string Number { get; set; }

        [Required]
        public PhoneNumberType PhoneNumberType { get; set; }

        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
