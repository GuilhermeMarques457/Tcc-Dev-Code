namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomething : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Telefone", c => c.String(nullable: false));
        }
    }
}
