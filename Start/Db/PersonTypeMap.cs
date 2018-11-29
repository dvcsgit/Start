using System.Data.Entity.ModelConfiguration;

namespace Start.Db
{
    public class PersonTypeMap : EntityTypeConfiguration<PersonType>
    {
        public PersonTypeMap()
        {
            //ToTable("TypeOfPerson");//Table name
            HasMany(pt => pt.Persons)
            .WithOptional(p => p.PersonType)
            .HasForeignKey(p => p.PersonTypeId)
            .WillCascadeOnDelete(false);
        }
    }
}
