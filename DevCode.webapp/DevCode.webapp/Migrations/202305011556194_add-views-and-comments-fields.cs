namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addviewsandcommentsfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perguntas", "Views", c => c.Int());
            AddColumn("dbo.Perguntas", "Comments", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perguntas", "Comments");
            DropColumn("dbo.Perguntas", "Views");
        }
    }
}
