namespace MEGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_slider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Slider_Id", c => c.Int());
            CreateIndex("dbo.Products", "Slider_Id");
            AddForeignKey("dbo.Products", "Slider_Id", "dbo.Sliders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Slider_Id", "dbo.Sliders");
            DropIndex("dbo.Products", new[] { "Slider_Id" });
            DropColumn("dbo.Products", "Slider_Id");
            DropTable("dbo.Sliders");
        }
    }
}
