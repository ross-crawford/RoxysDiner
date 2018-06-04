namespace BookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingModel",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        BookingDateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        PartySize = c.Int(nullable: false),
                        TableAllocation = c.Int(nullable: false),
                        BookingComments = c.String(),
                        Table_TableId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.TableModel", t => t.Table_TableId)
                .Index(t => t.Table_TableId);
            
            CreateTable(
                "dbo.CustomerModel",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        Telephone = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.BookingModel", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.TableModel",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        TableNumber = c.Int(nullable: false),
                        TableCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModel", "Table_TableId", "dbo.TableModel");
            DropForeignKey("dbo.CustomerModel", "CustomerId", "dbo.BookingModel");
            DropIndex("dbo.CustomerModel", new[] { "CustomerId" });
            DropIndex("dbo.BookingModel", new[] { "Table_TableId" });
            DropTable("dbo.TableModel");
            DropTable("dbo.CustomerModel");
            DropTable("dbo.BookingModel");
        }
    }
}
