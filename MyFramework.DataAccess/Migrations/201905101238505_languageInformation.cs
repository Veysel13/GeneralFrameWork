namespace MyFramework.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class languageInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.LanguageWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Code = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
           
        }
        
        public override void Down()
        {
            
            DropTable("dbo.LanguageWords");
            DropTable("dbo.Languages");
        }
    }
}
