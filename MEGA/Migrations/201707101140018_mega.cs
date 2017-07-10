namespace MEGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mega : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "oformlen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "oformlen");
        }
    }
}
