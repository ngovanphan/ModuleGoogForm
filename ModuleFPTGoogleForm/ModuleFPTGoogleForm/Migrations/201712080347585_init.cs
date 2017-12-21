namespace ModuleFPTGoogleForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnwserDetails",
                c => new
                    {
                        AnwserId = c.Int(nullable: false, identity: true),
                        Detail = c.String(nullable: false, maxLength: 1000),
                        UserId = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnwserId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionName = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Answer = c.String(),
                        FormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "FormId", "dbo.Forms");
            DropForeignKey("dbo.AnwserDetails", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "FormId" });
            DropIndex("dbo.AnwserDetails", new[] { "QuestionId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Forms");
            DropTable("dbo.AnwserDetails");
        }
    }
}
