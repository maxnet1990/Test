namespace Seekers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Jops",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        mobile = c.String(),
                        address = c.String(),
                        cityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .Index(t => t.cityId);
            
            CreateTable(
                "dbo.JopDates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        displayJopDate = c.DateTime(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        jopId = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jops", t => t.jopId, cascadeDelete: true)
                .ForeignKey("dbo.Catogeries", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.jopId)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Catogeries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        countryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Countries", t => t.countryId, cascadeDelete: true)
                .Index(t => t.countryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cities", new[] { "countryId" });
            DropIndex("dbo.JopDates", new[] { "categoryId" });
            DropIndex("dbo.JopDates", new[] { "jopId" });
            DropIndex("dbo.Jops", new[] { "cityId" });
            DropForeignKey("dbo.Cities", "countryId", "dbo.Countries");
            DropForeignKey("dbo.JopDates", "categoryId", "dbo.Catogeries");
            DropForeignKey("dbo.JopDates", "jopId", "dbo.Jops");
            DropForeignKey("dbo.Jops", "cityId", "dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Catogeries");
            DropTable("dbo.JopDates");
            DropTable("dbo.Jops");
            DropTable("dbo.UserProfile");
        }
    }
}
