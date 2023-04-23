namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlikestable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Perguntas", t => t.IDPergunta)
                .ForeignKey("dbo.Usuarios", t => t.IDUsuarioLiked)
                .Index(t => t.IDUsuarioLiked)
                .Index(t => t.IDPergunta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LikePerguntas", "IDUsuarioLiked", "dbo.Usuarios");
            DropForeignKey("dbo.LikePerguntas", "IDPergunta", "dbo.Perguntas");
            DropIndex("dbo.LikePerguntas", new[] { "IDPergunta" });
            DropIndex("dbo.LikePerguntas", new[] { "IDUsuarioLiked" });
            DropTable("dbo.LikePerguntas");
        }
    }
}
