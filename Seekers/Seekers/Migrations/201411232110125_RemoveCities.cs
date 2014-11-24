namespace Seekers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jops", "cityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "countryId", "dbo.Countries");
            DropIndex("dbo.Jops", new[] { "cityId" });
            DropIndex("dbo.Cities", new[] { "countryId" });
            DropColumn("dbo.Jops", "cityId");
            DropTable("dbo.Cities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        countryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Jops", "cityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "countryId");
            CreateIndex("dbo.Jops", "cityId");
            AddForeignKey("dbo.Cities", "countryId", "dbo.Countries", "id", cascadeDelete: true);
            AddForeignKey("dbo.Jops", "cityId", "dbo.Cities", "id", cascadeDelete: true);
        }
    }
}
