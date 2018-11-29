namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonPersonNamesIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Person", new[] { "LastName", "FirstName" }, name: "IX_PERSON_NAMES");
        }
        
        public override void Down()
        {
            DropIndex("Person", "IX_PERSON_NAMES");
        }
    }
}
