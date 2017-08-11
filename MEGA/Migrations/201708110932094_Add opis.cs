namespace MEGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addopis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewOrders", "Opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewOrders", "Opis");
        }
    }
}
