namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeaderToConnectGroup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KonnekGroeps", "KerkMemberLeaderId", c => c.Guid(nullable: false));
            AddColumn("dbo.KonnekGroeps", "KerkMemberLeader_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.KonnekGroeps", "KerkMemberLeader_Id");
            AddForeignKey("dbo.KonnekGroeps", "KerkMemberLeader_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KonnekGroeps", "KerkMemberLeader_Id", "dbo.AspNetUsers");
            DropIndex("dbo.KonnekGroeps", new[] { "KerkMemberLeader_Id" });
            DropColumn("dbo.KonnekGroeps", "KerkMemberLeader_Id");
            DropColumn("dbo.KonnekGroeps", "KerkMemberLeaderId");
        }
    }
}
