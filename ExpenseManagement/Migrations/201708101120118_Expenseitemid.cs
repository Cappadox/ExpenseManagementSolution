namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expenseitemid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VPExpenseItems", "VPExpense_Id", "dbo.VPExpenses");
            DropIndex("dbo.VPExpenseItems", new[] { "VPExpense_Id" });
            DropColumn("dbo.VPExpenseItems", "ExpenseId");
            RenameColumn(table: "dbo.VPExpenseItems", name: "VPExpense_Id", newName: "ExpenseId");
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int(nullable: false));
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.VPExpenseItems", "ExpenseId");
            AddForeignKey("dbo.VPExpenseItems", "ExpenseId", "dbo.VPExpenses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VPExpenseItems", "ExpenseId", "dbo.VPExpenses");
            DropIndex("dbo.VPExpenseItems", new[] { "ExpenseId" });
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int());
            AlterColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int());
            RenameColumn(table: "dbo.VPExpenseItems", name: "ExpenseId", newName: "VPExpense_Id");
            AddColumn("dbo.VPExpenseItems", "ExpenseId", c => c.Int());
            CreateIndex("dbo.VPExpenseItems", "VPExpense_Id");
            AddForeignKey("dbo.VPExpenseItems", "VPExpense_Id", "dbo.VPExpenses", "Id");
        }
    }
}
