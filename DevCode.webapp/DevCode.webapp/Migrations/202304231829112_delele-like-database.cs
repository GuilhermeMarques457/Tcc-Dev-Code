namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delelelikedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LikePerguntas", "IDPergunta", "dbo.Perguntas");
            DropForeignKey("dbo.LikePerguntas", "IDUsuarioLiked", "dbo.Usuarios");
            DropIndex("dbo.LikePerguntas", new[] { "IDUsuarioLiked" });
            DropIndex("dbo.LikePerguntas", new[] { "IDPergunta" });
            DropTable("dbo.LikePerguntas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LikePerguntas",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        IDUsuarioLiked = c.Int(nullable: false),
                        IDPergunta = c.Int(nullable: false),
                        TotalLikes = c.Int(),
                    })
                .PrimaryKey(t => t.LikeId);
            
            CreateIndex("dbo.LikePerguntas", "IDPergunta");
            CreateIndex("dbo.LikePerguntas", "IDUsuarioLiked");
            AddForeignKey("dbo.LikePerguntas", "IDUsuarioLiked", "dbo.Usuarios", "IDUsuario");
            AddForeignKey("dbo.LikePerguntas", "IDPergunta", "dbo.Perguntas", "IDPergunta");
        }
    }
}
