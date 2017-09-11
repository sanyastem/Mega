namespace MEGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Slider_Id", "dbo.Sliders");
            DropIndex("dbo.Products", new[] { "Slider_Id" });
            AddColumn("dbo.Products", "IdSlider", c => c.Int(nullable: false));
            AddColumn("dbo.Sliders", "Product_Id", c => c.Int());
            CreateIndex("dbo.Sliders", "Product_Id");
            AddForeignKey("dbo.Sliders", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "Slider_Id");
            DropColumn("dbo.Sliders", "IdProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "IdProduct", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Slider_Id", c => c.Int());
            DropForeignKey("dbo.Sliders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Sliders", new[] { "Product_Id" });
            DropColumn("dbo.Sliders", "Product_Id");
            DropColumn("dbo.Products", "IdSlider");
            CreateIndex("dbo.Products", "Slider_Id");
            AddForeignKey("dbo.Products", "Slider_Id", "dbo.Sliders", "Id");
        }
    }
}
