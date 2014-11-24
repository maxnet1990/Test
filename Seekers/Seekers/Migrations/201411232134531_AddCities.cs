namespace Seekers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Countries", t => t.country_Id, cascadeDelete: true)
                .Index(t => t.country_Id);
            
            AddColumn("dbo.Jops", "city_id", c => c.Int(nullable: false));
            AddForeignKey("dbo.Jops", "city_id", "dbo.Cities", "id", cascadeDelete: true);
            CreateIndex("dbo.Jops", "city_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cities", new[] { "country_Id" });
            DropIndex("dbo.Jops", new[] { "city_id" });
            DropForeignKey("dbo.Cities", "country_Id", "dbo.Countries");
            DropForeignKey("dbo.Jops", "city_id", "dbo.Cities");
            DropColumn("dbo.Jops", "city_id");
            DropTable("dbo.Cities");
        }
    }
}
