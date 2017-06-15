namespace MEGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MegaMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.NewOrders", new[] { "Order_Id" });
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            AddColumn("dbo.Orders", "NewOrder_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Orders", "NewOrder_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "NewOrder_Id", "dbo.NewOrders", "Id");
            DropColumn("dbo.Products", "Order_Id");
            DropColumn("dbo.NewOrders", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewOrders", "Order_Id", c => c.Int());
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "NewOrder_Id", "dbo.NewOrders");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "NewOrder_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropColumn("dbo.Orders", "NewOrder_Id");
            DropColumn("dbo.Orders", "Product_Id");
            CreateIndex("dbo.NewOrders", "Order_Id");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.NewOrders", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
