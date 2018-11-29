using System.Data.Entity.ModelConfiguration;

namespace Start.Db
{
    public class PersonViewInfoMap: EntityTypeConfiguration<PersonViewInfo>
    {
        public PersonViewInfoMap()
        {
            HasKey(p => p.PersonId);
            ToTable("PersonView");
        }
    }
}
