namespace EveryNationRandburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecondInCommandToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KonnekGroeps", "KerkMemberSecondInCommandId", c => c.Guid(nullable: false));
            AddColumn("dbo.KonnekGroeps", "KerkMemberSecondInCommand_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.KonnekGroeps", "KerkMemberSecondInCommand_Id");
            AddForeignKey("dbo.KonnekGroeps", "KerkMemberSecondInCommand_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KonnekGroeps", "KerkMemberSecondInCommand_Id", "dbo.AspNetUsers");
            DropIndex("dbo.KonnekGroeps", new[] { "KerkMemberSecondInCommand_Id" });
            DropColumn("dbo.KonnekGroeps", "KerkMemberSecondInCommand_Id");
            DropColumn("dbo.KonnekGroeps", "KerkMemberSecondInCommandId");
        }
    }
}
