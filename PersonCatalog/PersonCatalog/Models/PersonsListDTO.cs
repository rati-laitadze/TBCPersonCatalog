using PersonCatalog.Models;
using System.Collections.Generic;

namespace PersonCatalog.Web.Models
{
    public class PersonsListDTO
    {
        public int TotalPageNumber { get; set; }
        public List<PersonDTO> PersonDTOs { get; set; }
    }
}
