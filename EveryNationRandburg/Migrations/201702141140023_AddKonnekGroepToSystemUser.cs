namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKonnekGroepToSystemUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "KonnekGroepId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "KonnekGroepId");
        }
    }
}
