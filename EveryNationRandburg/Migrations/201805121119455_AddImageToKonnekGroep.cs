namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToKonnekGroep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KonnekGroeps", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KonnekGroeps", "Image");
        }
    }
}
