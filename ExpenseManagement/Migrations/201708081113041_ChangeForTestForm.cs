namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForTestForm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VPExpenseItems", "ExpenseId", "dbo.VPExpenses");
            DropIndex("dbo.VPExpenseItems", new[] { "ExpenseId" });
            RenameColumn(table: "dbo.VPExpenseItems", name: "ExpenseId", newName: "VPExpense_Id");
            AddColumn("dbo.VPExpenseItems", "Description", c => c.String());
            AlterColumn("dbo.VPExpenseItems", "VPExpense_Id", c => c.Int());
            CreateIndex("dbo.VPExpenseItems", "VPExpense_Id");
            AddForeignKey("dbo.VPExpenseItems", "VPExpense_Id", "dbo.VPExpenses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VPExpenseItems", "VPExpense_Id", "dbo.VPExpenses");
            DropIndex("dbo.VPExpenseItems", new[] { "VPExpense_Id" });
            AlterColumn("dbo.VPExpenseItems", "VPExpense_Id", c => c.Int(nullable: false));
            DropColumn("dbo.VPExpenseItems", "Description");
            RenameColumn(table: "dbo.VPExpenseItems", name: "VPExpense_Id", newName: "ExpenseId");
            CreateIndex("dbo.VPExpenseItems", "ExpenseId");
            AddForeignKey("dbo.VPExpenseItems", "ExpenseId", "dbo.VPExpenses", "Id", cascadeDelete: true);
        }
    }
}
