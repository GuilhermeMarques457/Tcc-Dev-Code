namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconfirmpasswordfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "ConfirmarSenha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "ConfirmarSenha");
        }
    }
}
