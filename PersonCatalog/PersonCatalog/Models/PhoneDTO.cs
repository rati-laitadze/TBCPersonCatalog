using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class PhoneDTO
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string PhoneNumberType { get; set; }
    }
}
