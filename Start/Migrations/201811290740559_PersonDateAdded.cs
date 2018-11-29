namespace Start.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "DateAdded", c => c.DateTime(nullable: false,defaultValueSql:"GetDate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "DateAdded");
        }
    }
}
