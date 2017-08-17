namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VPExpenses", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.VPExpenses", "ExpenseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VPExpenses", "ExpenseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VPExpenses", "ModifyDate", c => c.DateTime(nullable: false));
        }
    }
}
