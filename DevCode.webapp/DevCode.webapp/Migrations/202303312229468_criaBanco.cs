namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criaBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perguntas",
                c => new
                    {
                        IDPergunta = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Detalhes = c.String(),
                        Esperado = c.String(),
                        DataEnvio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPergunta);
            
            CreateTable(
                "dbo.Respostas",
                c => new
                    {
                        IDRespostas = c.Int(nullable: false, identity: true),
                        ExplicacaoResposta = c.String(),
                        IDPergunta = c.Int(nullable: false),
                        IDUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDRespostas);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        Pontos = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Respostas");
            DropTable("dbo.Perguntas");
        }
    }
}
