using Start.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new Context())
            {
                context.Database.CreateIfNotExists();
                var person = new Person
                {
                    FirstName = "Rechor",
                    LastName = "Eofijgf"
                };
                context.People.Add(person);
                context.SaveChanges();
            }
        }
    }
}
