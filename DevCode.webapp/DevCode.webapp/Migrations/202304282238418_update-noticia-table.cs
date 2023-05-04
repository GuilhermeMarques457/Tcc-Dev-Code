namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenoticiatable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "IDUsuarioNoticia", c => c.Int(nullable: false));
            AddColumn("dbo.Noticias", "Likes", c => c.Int());
            CreateIndex("dbo.Noticias", "IDUsuarioNoticia");
            AddForeignKey("dbo.Noticias", "IDUsuarioNoticia", "dbo.Usuarios", "IDUsuario");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "IDUsuarioNoticia", "dbo.Usuarios");
            DropIndex("dbo.Noticias", new[] { "IDUsuarioNoticia" });
            DropColumn("dbo.Noticias", "Likes");
            DropColumn("dbo.Noticias", "IDUsuarioNoticia");
        }
    }
}
