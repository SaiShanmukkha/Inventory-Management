-- ADD multiple purchased Items

CREATE procedure [dbo].[Add_Multiple_Purchased_Items]
(@tableproducts [CartItemsType2] readonly)

AS
begin
insert into [dbo].[PurchasedItems]   select  [PurchaseInvoiceNumber], [ItemName], [ItemPrice], [ItemQuantity], [ItemSupplierId], [PurchaseOrderID] from @tableproducts
end
GO


-- Add purchase order
CREATE procedure [dbo].[Add_Purchase_Order]
@PurchaseInvoiceNumber nvarchar(40),
@PurchaseTransactionID nvarchar(40),
@PurchaseCourierCharge float,
@PurchaseTotalPrice float,
@PurchaseDate datetime2,
@PurchaseOrderID int output

AS
insert into [dbo].[PurchaseOrders]  
values(
@PurchaseDate,
@PurchaseTotalPrice,
@PurchaseInvoiceNumber,
@PurchaseTransactionID,
@PurchaseCourierCharge
)

SELECT @PurchaseOrderID = SCOPE_IDENTITY();
GO

-- Add Purchased Items
CREATE procedure [dbo].[Add_Purchased_Items]
@PurchaseInvoiceNumber nvarchar(40),
@ItemName nvarchar(40),
@Itemprice float,
@ItemQuantity int,
@ItemSupplierId int,
@PurchaseOrderId int

AS
insert into [dbo].[PurchasedItems]  
values(
@PurchaseInvoiceNumber,
@ItemName,
@Itemprice,
@ItemQuantity,
@ItemSupplierId,
@PurchaseOrderId
)
GO

-- SP for Recent 5 purchase orders
CREATE Procedure [dbo].[Get_Recent_Purchase_Orders]
As
Select top 5 * from [dbo].[PurchaseOrders] order by PurchaseOrderID DESC
GO



