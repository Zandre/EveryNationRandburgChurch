namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageObject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageContent = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.KonnekGroeps", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KonnekGroeps", "Image", c => c.Binary());
            DropTable("dbo.Images");
        }
    }
}
