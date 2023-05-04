namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtagsfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perguntas", "TagPrincipal", c => c.Int(nullable: false));
            AddColumn("dbo.Perguntas", "TagSecundaria", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perguntas", "TagSecundaria");
            DropColumn("dbo.Perguntas", "TagPrincipal");
        }
    }
}
