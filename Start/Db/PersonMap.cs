using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Start.Db
{
    public class PersonMap:EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            Property(p => p.FirstName)
            .HasMaxLength(30)
            .IsRequired();
            Property(p => p.LastName)
            .HasMaxLength(30);
            Property(p => p.MiddleName)
            .HasMaxLength(1)
            .IsFixedLength()
            .IsUnicode(false);
            Property(p => p.HeightInFeet)
            .HasPrecision(4, 2);
            Property(p => p.Photo)
            .IsVariableLength()
            .HasMaxLength(4000);

            //HasMany(p => p.Phones)
            //    .WithRequired()
            //    .HasForeignKey(ph => ph.PersonId);

            //HasMany(p => p.Companies)
            //    .WithMany(c => c.Persons)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("PersonId");
            //        m.MapRightKey("CompanyId");
            //    });

            Ignore(p => p.FullName);

            Map(p =>
            {
                p.Properties(ph =>
                new
                {
                    ph.Photo,
                    ph.FamilyPicture
                });
                p.ToTable("PersonBlob");
            });

            Map(p =>
            {
                p.Properties(ph =>
                new
                {
                    ph.FirstName,
                    ph.MiddleName,
                    ph.LastName,
                    ph.BirthDate,
                    ph.Age,
                    ph.HeightInFeet,
                    ph.Address,
                    ph.NumberOfCars,
                    ph.IsActive,
                    ph.PersonState,
                    ph.PersonTypeId,
                    ph.DateAdded,
                    ph.RowVerson
                });
                p.ToTable("Person");
            });

            Property(p => p.RowVerson)
                .IsFixedLength()
                .HasMaxLength(8)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .IsRowVersion();
        }
    }
}
