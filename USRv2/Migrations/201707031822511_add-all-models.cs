namespace USRv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addallmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainTableProperties",
                c => new
                    {
                        MainTablePropertieId = c.Int(nullable: false),
                        SclMax = c.Single(nullable: false),
                        SclMin = c.Single(nullable: false),
                        IsCutOffMax = c.Boolean(nullable: false),
                        CutOffMax = c.Single(nullable: false),
                        IsCutOffMin = c.Boolean(nullable: false),
                        CutOffMin = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MainTablePropertieId)
                .ForeignKey("dbo.MainTables", t => t.MainTablePropertieId)
                .Index(t => t.MainTablePropertieId);
            
            CreateTable(
                "dbo.MainTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlcId = c.Int(nullable: false),
                        LabelId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        IdAsc = c.Int(nullable: false),
                        IsContainer = c.Boolean(nullable: false),
                        Container = c.String(maxLength: 50),
                        IsOutOfView = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Labels", t => t.LabelId, cascadeDelete: true)
                .ForeignKey("dbo.Plcs", t => t.PlcId, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.PlcId)
                .Index(t => t.LabelId)
                .Index(t => t.TitleId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.NumericSamples",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        SampleDateTime = c.DateTime(nullable: false),
                        SampleValue = c.Single(nullable: false),
                        QualityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.SampleDateTime })
                .ForeignKey("dbo.MainTables", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Qualities", t => t.QualityId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.QualityId);
            
            CreateTable(
                "dbo.Qualities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        DepName = c.String(nullable: false, maxLength: 10),
                        IsVisibleInMenu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainTableProperties", "MainTablePropertieId", "dbo.MainTables");
            DropForeignKey("dbo.MainTables", "UnitId", "dbo.Units");
            DropForeignKey("dbo.MainTables", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.MainTables", "PlcId", "dbo.Plcs");
            DropForeignKey("dbo.NumericSamples", "QualityId", "dbo.Qualities");
            DropForeignKey("dbo.NumericSamples", "TagId", "dbo.MainTables");
            DropForeignKey("dbo.MainTables", "LabelId", "dbo.Labels");
            DropIndex("dbo.NumericSamples", new[] { "QualityId" });
            DropIndex("dbo.NumericSamples", new[] { "TagId" });
            DropIndex("dbo.MainTables", new[] { "UnitId" });
            DropIndex("dbo.MainTables", new[] { "TitleId" });
            DropIndex("dbo.MainTables", new[] { "LabelId" });
            DropIndex("dbo.MainTables", new[] { "PlcId" });
            DropIndex("dbo.MainTableProperties", new[] { "MainTablePropertieId" });
            DropTable("dbo.Units");
            DropTable("dbo.Titles");
            DropTable("dbo.Plcs");
            DropTable("dbo.Qualities");
            DropTable("dbo.NumericSamples");
            DropTable("dbo.MainTables");
            DropTable("dbo.MainTableProperties");
            DropTable("dbo.Labels");
        }
    }
}
