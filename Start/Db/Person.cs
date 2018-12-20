using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Db
{
    public class Person
    {
        //public int PersonId { get; set; }
        //[MaxLength(30, ErrorMessage = "First name cannot be longer than 30")]
        //public string FirstName { get; set; }
        //[MaxLength(30)]
        //public string LastName { get; set; }
        //[StringLength(1, MinimumLength = 1)]
        //[Column(TypeName = "char")]
        //public string MiddleName { get; set; }

        public Person()
        {
            Phones = new HashSet<Phone>();//
            Address = new Address();
        }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }//?表示允许值类型为null
        public int Age { get; set; }
        public decimal HeightInFeet { get; set; }

        public byte[] Photo { get; set; }
        public byte[] FamilyPicture { get; set; }

        public bool IsActive { get; set; }
        public int NumberOfCars { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }//lazy loading

        public Guid? PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public Student Student { get; set; }

        public Address Address { get; set; }

        public string FullName//This is a supporting column.Look details from the PersonMap.
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set
            {
                var names = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                FirstName = names[0];
                LastName = names[1];
            }
        }

        public PersonState PersonState { get; set; }

        public DateTime? DateAdded { get; set; }

        public byte[] RowVerson { get; set; }//TimeStamp
    }
}
