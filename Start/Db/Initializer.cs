using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Db
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Database.ExecuteSqlCommand("DROP TABLE PersonView");
            context.Database.ExecuteSqlCommand(
            @"CREATE VIEW [dbo].[PersonView]
            AS
            SELECT
            dbo.Person.PersonId,
            dbo.Person.FirstName,
            dbo.Person.LastName,
            dbo.PersonTypes.TypeName
            FROM
            dbo.Person
            INNER JOIN dbo.PersonTypes
            ON dbo.Person.PersonTypeId =
            dbo.PersonTypes.PersonTypeId
            ");

            context.Database.ExecuteSqlCommand(@"CREATE PROCEDURE [dbo].[SelectCompanies]
@street as nvarchar(50)
AS
BEGIN
SELECT CompanyId, CompanyName
FROM Companies
WHERE Street = @street
END");

            //var person = new Person
            //{
            //    FirstName = "Rechor",
            //    LastName = "Eofijgf"
            //};
            //context.People.Add(person);

            //var person = new Person
            //{
            //    LastName = "Doe",
            //    FirstName = "John",
            //    IsActive = true
            //};
            //person.Phones.Add(new Phone { PhoneNumber = "123-446-7890" });
            //person.Phones.Add(new Phone { PhoneNumber = "123-446-7891" });
            //context.People.Add(person);

            //context.Companies.Add(new Company { Name = "My company" });
        }
    }
}
