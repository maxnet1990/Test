namespace Seekers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjopDate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JopDates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        displayJopDate = c.DateTime(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        jop_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jops", t => t.jop_id, cascadeDelete: true)
                .ForeignKey("dbo.Catogeries", t => t.category_id, cascadeDelete: true)
                .Index(t => t.jop_id)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JopDates", new[] { "category_id" });
            DropIndex("dbo.JopDates", new[] { "jop_id" });
            DropForeignKey("dbo.JopDates", "category_id", "dbo.Catogeries");
            DropForeignKey("dbo.JopDates", "jop_id", "dbo.Jops");
            DropTable("dbo.JopDates");
        }
    }
}
