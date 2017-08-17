namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabledatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VPExpenseItems", "ModifyDate", c => c.DateTime());
            AlterColumn("dbo.VPExpenseItems", "ExpenseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VPExpenseItems", "ExpenseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VPExpenseItems", "ModifyDate", c => c.DateTime(nullable: false));
        }
    }
}
