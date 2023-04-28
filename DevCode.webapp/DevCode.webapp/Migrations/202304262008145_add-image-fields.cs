namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimagefields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "CaminhoImagemPerfil", c => c.String());
            AddColumn("dbo.Usuarios", "CaminhoImagemBanner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "CaminhoImagemBanner");
            DropColumn("dbo.Usuarios", "CaminhoImagemPerfil");
        }
    }
}
