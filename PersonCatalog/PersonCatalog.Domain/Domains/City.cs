using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Domains
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
