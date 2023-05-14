namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtableamigos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amizades",
                c => new
                    {
                        IDAmizade = c.Int(nullable: false, identity: true),
                        IDUsuarioPedido = c.Int(nullable: false),
                        IDUsuarioResposta = c.Int(nullable: false),
                        Pendente = c.Boolean(nullable: false),
                        Amigos = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDAmizade)
                .ForeignKey("dbo.Usuarios", t => t.IDUsuarioPedido)
                .ForeignKey("dbo.Usuarios", t => t.IDUsuarioResposta)
                .Index(t => t.IDUsuarioPedido)
                .Index(t => t.IDUsuarioResposta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Amizades", "IDUsuarioResposta", "dbo.Usuarios");
            DropForeignKey("dbo.Amizades", "IDUsuarioPedido", "dbo.Usuarios");
            DropIndex("dbo.Amizades", new[] { "IDUsuarioResposta" });
            DropIndex("dbo.Amizades", new[] { "IDUsuarioPedido" });
            DropTable("dbo.Amizades");
        }
    }
}
