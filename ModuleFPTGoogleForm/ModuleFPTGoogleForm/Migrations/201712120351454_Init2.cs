namespace ModuleFPTGoogleForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnwserDetails", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnwserDetails", "UserId", c => c.String(nullable: false));
        }
    }
}
