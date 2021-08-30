using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Models
{
    public class RelativeDTO
    {
        public int ID { get; set; }
        public string RelationType { get; set; }
        public int PersonToID { get; set; }
        public int PersonFromID { get; set; }
    }
}
