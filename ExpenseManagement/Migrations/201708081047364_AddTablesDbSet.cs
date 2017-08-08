namespace ExpenseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VPExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        DateOfExpense = c.DateTime(),
                        ExpenseHistory_Id = c.Int(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VPExpenseHistories", t => t.ExpenseHistory_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.ExpenseHistory_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.VPExpenseHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsPaid = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(),
                        DateOfApproval = c.DateTime(nullable: false),
                        DateOfPayment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VPExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        DateOfExpense = c.DateTime(nullable: false),
                        Amount = c.Single(nullable: false),
                        ExpenseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VPExpenses", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ExpenseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VPExpenses", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.VPExpenseItems", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VPExpenseItems", "ExpenseId", "dbo.VPExpenses");
            DropForeignKey("dbo.VPExpenses", "ExpenseHistory_Id", "dbo.VPExpenseHistories");
            DropIndex("dbo.VPExpenseItems", new[] { "ExpenseId" });
            DropIndex("dbo.VPExpenseItems", new[] { "UserId" });
            DropIndex("dbo.VPExpenses", new[] { "Users_Id" });
            DropIndex("dbo.VPExpenses", new[] { "ExpenseHistory_Id" });
            DropTable("dbo.VPExpenseItems");
            DropTable("dbo.VPExpenseHistories");
            DropTable("dbo.VPExpenses");
        }
    }
}
