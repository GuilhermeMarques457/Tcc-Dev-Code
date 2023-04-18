namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        IDNoticia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Detalhes = c.String(),
                        DataEnvio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDNoticia);
            
            CreateTable(
                "dbo.Perguntas",
                c => new
                    {
                        IDPergunta = c.Int(nullable: false, identity: true),
                        IDUsuarioPergunta = c.Int(nullable: false),
                        Titulo = c.String(),
                        Detalhes = c.String(),
                        Esperado = c.String(),
                        DataEnvio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPergunta)
                .ForeignKey("dbo.Usuarios", t => t.IDUsuarioPergunta)
                .Index(t => t.IDUsuarioPergunta);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IDUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        Pontos = c.Int(),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
            CreateTable(
                "dbo.Respostas",
                c => new
                    {
                        IDRespostas = c.Int(nullable: false, identity: true),
                        ExplicacaoResposta = c.String(),
                        IDUsuarioResposta = c.Int(nullable: false),
                        IDPergunta = c.Int(nullable: false),
                        DataResposta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDRespostas)
                .ForeignKey("dbo.Perguntas", t => t.IDPergunta)
                .ForeignKey("dbo.Usuarios", t => t.IDUsuarioResposta)
                .Index(t => t.IDUsuarioResposta)
                .Index(t => t.IDPergunta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Respostas", "IDUsuarioResposta", "dbo.Usuarios");
            DropForeignKey("dbo.Respostas", "IDPergunta", "dbo.Perguntas");
            DropForeignKey("dbo.Perguntas", "IDUsuarioPergunta", "dbo.Usuarios");
            DropIndex("dbo.Respostas", new[] { "IDPergunta" });
            DropIndex("dbo.Respostas", new[] { "IDUsuarioResposta" });
            DropIndex("dbo.Perguntas", new[] { "IDUsuarioPergunta" });
            DropTable("dbo.Respostas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Perguntas");
            DropTable("dbo.Noticias");
        }
    }
}
