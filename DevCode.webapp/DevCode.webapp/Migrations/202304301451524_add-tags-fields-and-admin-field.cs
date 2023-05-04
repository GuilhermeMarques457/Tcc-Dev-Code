namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtagsfieldsandadminfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "TagPrincipal", c => c.Int(nullable: false));
            AddColumn("dbo.Noticias", "TagSecundaria", c => c.Int());
            AddColumn("dbo.Usuarios", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Admin");
            DropColumn("dbo.Noticias", "TagSecundaria");
            DropColumn("dbo.Noticias", "TagPrincipal");
        }
    }
}
