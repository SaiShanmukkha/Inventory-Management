-- sp for adding multiple sold items

CREATE procedure [dbo].[Add_Multiple_Sold_Items]
(@tableproducts [SoldCartItemsType] readonly)

AS
begin
insert into [dbo].[SoldItems]   select  [ItemName], [ItemPrice], [ItemQuantity], [SellOrderID],[SellInvoiceNumber] from @tableproducts
end
GO

-- sp for add sell order
CREATE procedure [dbo].[Add_Sell_Order]
@SellInvoiceNumber nvarchar(40),
@SellTransactionID nvarchar(40),
@CustomerName nvarchar(40),
@CustomerPhone bigint,
@CustomerEmail nvarchar(30),
@SellCourierCharge float,
@SellTotalPrice float,
@SellDate datetime2,
@SellOrderID int output

AS
insert into [dbo].[SellOrders]  
values(
@SellDate,
@CustomerName,
@CustomerPhone,
@CustomerEmail,
@SellTotalPrice,
@SellInvoiceNumber,
@SellTransactionID,
@SellCourierCharge
)

SELECT @SellOrderID = SCOPE_IDENTITY();
GO

-- sp for recent 5 sell orders
CREATE Procedure [dbo].[Get_Recent_Sell_Orders]
As
Select top 5 * from [dbo].[SellOrders] order by SellOrderID DESC
GO

