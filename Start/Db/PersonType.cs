using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Db
{
    public class PersonType
    {
        public Guid PersonTypeId { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
