namespace DevCode.webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addliketoanswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Respostas", "Likes", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Respostas", "Likes");
        }
    }
}
