namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurnameToSystemUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Surname");
        }
    }
}
