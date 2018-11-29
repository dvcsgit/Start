using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Db
{
    public class AddressMap : ComplexTypeConfiguration<Address>
    {
        public AddressMap()
        {
            Property(p => p.Street)
                .HasMaxLength(40)
                .IsRequired()
            .HasColumnName("Street");
        }
    }
}
