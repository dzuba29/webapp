namespace webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Product_Insert",
                p => new
                    {
                        ShortName = p.String(),
                        FullName = p.String(),
                        ShelfNumber = p.Int(),
                        Weight = p.Double(),
                        DateIn = p.DateTime(),
                        DateOut = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Products]([ShortName], [FullName], [ShelfNumber], [Weight], [DateIn], [DateOut])
                      VALUES (@ShortName, @FullName, @ShelfNumber, @Weight, @DateIn, @DateOut)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[Products]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[Products] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.Product_Update",
                p => new
                    {
                        ID = p.Int(),
                        ShortName = p.String(),
                        FullName = p.String(),
                        ShelfNumber = p.Int(),
                        Weight = p.Double(),
                        DateIn = p.DateTime(),
                        DateOut = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Products]
                      SET [ShortName] = @ShortName, [FullName] = @FullName, [ShelfNumber] = @ShelfNumber, [Weight] = @Weight, [DateIn] = @DateIn, [DateOut] = @DateOut
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.Product_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Products]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Product_Delete");
            DropStoredProcedure("dbo.Product_Update");
            DropStoredProcedure("dbo.Product_Insert");
        }
    }
}
