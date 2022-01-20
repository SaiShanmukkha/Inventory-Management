
/*Stored procedures for Adding item */
Create procedure Add_Item
@ItemName nvarchar(40),
@ItemQuantity int,
@ItemPrice float,
@ItemCreationDate datetime2,
@ItemLastUpdate datetime2
As 
insert into [dbo].[Items]  
values(
@ItemName,
@ItemQuantity,
@ItemPrice,
@ItemCreationDate,
@ItemLastUpdate
)
Go

/*Stored procedures for Getting Items */
Create Procedure Get_Items
As
Select * from [dbo].[Items]
Go

/*Stored procedures for Updating item */
Create Procedure Update_Item
@ItemID int,
@ItemName nvarchar(40),
@ItemQuantity int,
@ItemPrice float,
@ItemCreationDate datetime2,
@ItemLastUpdate datetime2
As
update [dbo].[Items] 
set 
ItemName=@ItemName,
ItemQuantity=@ItemQuantity,
ItemPrice=@ItemPrice,
ItemCreationDate=@ItemCreationDate,
ItemLastUpdate=@ItemLastUpdate
where ItemID = @ItemID
Go

/*Stored procedures for Deleting item */
create procedure Delete_Item
@ItemID int
As
Delete from [dbo].[Items]
where ItemID = @ItemID
Go

/*Stored procedures for Getting item by Id */
create procedure Get_Item_By_Id
@ItemID int
AS
Select * from [dbo].[Items]
where  ItemID = @ItemID
Go


/*SP for Update item Quantity*/
Create Procedure [dbo].[Update_Item_Quantity]
@ItemID int,
@ItemQuantity int,
@ItemLastUpdate datetime2
As
update [dbo].[Items] 
set 
ItemQuantity=@ItemQuantity,
ItemLastUpdate=@ItemLastUpdate
where ItemID = @ItemID
GO



