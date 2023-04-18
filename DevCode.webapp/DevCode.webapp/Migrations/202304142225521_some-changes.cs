namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Perguntas", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Perguntas", "Detalhes", c => c.String(nullable: false));
            AlterColumn("dbo.Perguntas", "Esperado", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Perguntas", "Esperado", c => c.String());
            AlterColumn("dbo.Perguntas", "Detalhes", c => c.String());
            AlterColumn("dbo.Perguntas", "Titulo", c => c.String());
        }
    }
}
