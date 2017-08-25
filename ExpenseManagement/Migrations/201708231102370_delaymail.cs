namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delaymail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VPExpenses", "IsDelayMailSend", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VPExpenses", "IsDelayMailSend");
        }
    }
}
