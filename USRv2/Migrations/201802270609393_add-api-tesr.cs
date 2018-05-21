namespace USRv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapitesr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Singer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Singers", t => t.Singer_Id)
                .Index(t => t.Singer_Id);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Singer_Id", "dbo.Singers");
            DropIndex("dbo.Albums", new[] { "Singer_Id" });
            DropTable("dbo.Singers");
            DropTable("dbo.Albums");
        }
    }
}
