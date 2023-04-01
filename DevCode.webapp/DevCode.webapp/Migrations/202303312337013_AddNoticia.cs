namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoticia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticia",
                c => new
                    {
                        IDNoticia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Detalhes = c.String(),
                        DataEnvio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDNoticia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Noticia");
        }
    }
}
