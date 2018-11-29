using System.Data.Entity;

namespace Start.Db
{
    public class Context:DbContext
    {
        public Context() : base("name=dbstart")
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<PersonViewInfo> PersonView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonTypeMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PersonViewInfoMap());
        }

    }
}
