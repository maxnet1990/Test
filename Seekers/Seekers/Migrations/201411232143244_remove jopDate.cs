namespace Seekers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removejopDate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JopDates", "jopId", "dbo.Jops");
            DropForeignKey("dbo.JopDates", "categoryId", "dbo.Catogeries");
            DropIndex("dbo.JopDates", new[] { "jopId" });
            DropIndex("dbo.JopDates", new[] { "categoryId" });
            DropTable("dbo.JopDates");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.JopDates", "categoryId");
            CreateIndex("dbo.JopDates", "jopId");
            AddForeignKey("dbo.JopDates", "categoryId", "dbo.Catogeries", "id", cascadeDelete: true);
            AddForeignKey("dbo.JopDates", "jopId", "dbo.Jops", "id", cascadeDelete: true);
        }
    }
}
