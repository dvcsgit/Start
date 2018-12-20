using Start.Db;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new Initializer());

            //ConcurrencyExample();

            //using (var context = new Context())
            //{
            //    context.Database.CreateIfNotExists();               
            //    var person = new Person
            //    {
            //        FirstName = "Rechor",
            //        LastName = "Eofijgf"
            //    };
            //    context.People.Add(person);
            //    context.SaveChanges();
            //}

            try
            {
                using (var context = new Context())
                {
                    Guid guid = Guid.NewGuid();
                    var person = new Person
                    {
                        BirthDate = new DateTime(1980, 1, 2),
                        FirstName = "John",
                        HeightInFeet = 6.1M,
                        IsActive = true,
                        LastName = "Doe",
                        MiddleName = "M",
                        Address = new Address { Street = "new street" },
                        PersonState = PersonState.Active,
                        PersonTypeId = guid
                    };
                    //var personViewInfo = new PersonViewInfo
                    //{
                    //    FirstName = "f",
                    //    LastName = "l",
                    //    TypeName = "type"
                    //};
                    //context.PersonView.Add(personViewInfo);

                    context.PersonTypes.Add(new PersonType {PersonTypeId= guid, TypeName = "type0" });

                    person.Phones.Add(new Phone { PhoneNumber = "123-446-7890" });
                    person.Phones.Add(new Phone { PhoneNumber = "123-446-7891" });
                    context.People.Add(person);

                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {

            }

            //using (var context = new Context())
            //{
            //    var person = context.People.Find(1);
            //    person.FirstName = "New Name";
            //    context.SaveChanges();
            //}

            using (var context = new Context())
            {
                //var savedPeople = context.People
                //    .Where(p => p.PersonState == PersonState.Active)
                //    .OrderBy(p => p.LastName)
                //    .ThenBy(p => p.FirstName)
                //    .Select(p => new
                //    {
                //        p.LastName,
                //        p.FirstName,
                //        p.PersonType.TypeName
                //    });

                //var savedPeople = context.People
                //    .Where(p => p.PersonState == PersonState.Active)
                //    .OrderBy(p => p.LastName)
                //    .ThenBy(p => p.FirstName)
                //    .Select(p => new PersonInfo
                //    {
                //        LastName = p.LastName,
                //        FirstName = p.FirstName,
                //        PersonType = p.PersonType.TypeName,
                //        PersonId = p.PersonId,
                //        Phones = p.Phones.Select(ph => ph.PhoneNumber)
                //    });
                //foreach (var person in savedPeople)
                //{
                //    Console.WriteLine("Last name:{0},first name:{1},{2},{3}", person.LastName, person.FirstName, person.PersonType, person.PersonId);
                //    foreach (var phone in person.Phones)
                //    {
                //        Console.WriteLine(" " + phone);
                //    }
                //}

                //var savedPeople = context.People
                //    .Join(
                //    context.PersonTypes,
                //    person => person.PersonTypeId,
                //    personType => personType.PersonTypeId,
                //    (person, personType) => new
                //    {
                //        Person = person,
                //        PersonType = personType
                //    })
                //    .Select(p => new
                //    {
                //        p.Person.LastName,
                //        p.Person.FirstName,
                //        p.PersonType.TypeName
                //    });

                //foreach (var person in savedPeople)
                //{
                //    Console.WriteLine("Last name:{0},first name:{1},{2}", person.LastName, person.FirstName, person.TypeName);
                //}

                //var people = context.PersonView
                //             .Where(p => p.PersonId > 0)
                //             .OrderBy(p => p.LastName)
                //             .ToList();
                //foreach (var personViewInfo in people)
                //{
                //    Console.WriteLine(personViewInfo.LastName);
                //}

                //var sql = @"SELECT * FROM PERSONVIEW WHERE PERSONID > {0} ";
                //var peopleViaCommand =
                //context.Database.SqlQuery<PersonViewInfo>(
                //sql,
                //0);
                //foreach (var personViewInfo in peopleViaCommand)
                //{
                //    Console.WriteLine(personViewInfo.LastName);
                //}

                //var sql = @"SelectCompanies {0}";
                //var companies = context.Database.SqlQuery<CompanyInfo>(
                //sql,
                //"street1");
                //foreach (var companyInfo in companies)
                //{
                //    Console.WriteLine(companyInfo.CompanyName);
                //}

                var people = context.PersonView                          
                             .ToList();
                foreach (var personViewInfo in people)
                {
                    Console.WriteLine(personViewInfo.LastName);
                }
            }

            //using (var context=new Context())
            //{
            //    var savedPeople = context.People;
            //    if (savedPeople.Any())
            //    {
            //        var person = savedPeople.First();
            //        person.FirstName = "Johnny";
            //        person.LastName = "Benson";
            //        context.SaveChanges();
            //    }
            //}

            //using (var context = new Context())
            //{
            //    var personId = 1;
            //    var person = context.People.Find(personId);
            //    if (person != null)
            //    {
            //        context.People.Remove(person);
            //        context.SaveChanges();
            //    }
            //}
        }

        //private static void ConcurrencyExample()
        //{
        //    var person = new Person
        //    {
        //        BirthDate = new DateTime(1970, 1, 2),
        //        FirstName = "Aaron",
        //        HeightInFeet = 6M,
        //        IsActive = true,
        //        LastName = "Smith",
        //        Address = new Address { Street = "new street" }
        //    };
        //    int personId;
        //    using (var context=new Context())
        //    {
        //        context.People.Add(person);
        //        context.SaveChanges();
        //        personId = person.PersonId;
        //    }
        //    //Simulate second user.
        //    using (var context = new Context())
        //    {
        //        context.People.Find(personId).IsActive = false;
        //        context.SaveChanges();
        //    }
        //    //Back to first user.
        //    try
        //    {
        //        using (var context = new Context())
        //        {
        //            context.Entry(person).State = System.Data.Entity.EntityState.Unchanged;
        //            person.IsActive = false;
        //            context.SaveChanges();
        //        }
        //        Console.WriteLine("Concurrency error should occur!");
        //    }
        //    catch (DbUnexpectedValidationException)
        //    {
        //        Console.WriteLine("Expected concurrency error");
        //    }
        //    Console.ReadKey();
        //}
    }
}
