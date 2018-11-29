using System.Collections.Generic;

namespace Start.Db
{
    public class Company
    {
        public Company()
        {
            Persons = new HashSet<Person>();
            Address = new Address();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Address Address{get;set;}
        public virtual ICollection<Person> Persons { get; set; }
    }
}
