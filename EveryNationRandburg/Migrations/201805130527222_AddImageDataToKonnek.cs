namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageDataToKonnek : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KonnekGroeps", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KonnekGroeps", "ImageData");
        }
    }
}
