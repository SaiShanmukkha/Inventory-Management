/* Stored Procedure for Adding Suppliers */

create procedure Add_Supplier
@SupplierName nvarchar(40),
@SupplierIndustry nvarchar(40),
@SupplierEmail nvarchar(30),
@SupplierPhone int,
@SupplierAddress nvarchar(50),
@SupplierJoinDate datetime2,
@SupplierRating decimal(1,1),
@SupplierCity nvarchar(15),
@SupplierProvince nvarchar(15),
@SupplierCountry nvarchar(15),
@SupplierPinCode int,
@SupplierDataLastUpdate datetime2
As
Insert into [dbo].[Suppliers]
values(
@SupplierName,
@SupplierIndustry,
@SupplierEmail,
@SupplierPhone,
@SupplierAddress,
@SupplierJoinDate,
@SupplierRating,
@SupplierCity,
@SupplierProvince,
@SupplierCountry,
@SupplierPinCode,
@SupplierDataLastUpdate)
Go


/* Stored Procedure for Updating Suppliers */

create procedure Update_Supplier
@SupplierId int,
@SupplierName nvarchar(40),
@SupplierIndustry nvarchar(40),
@SupplierEmail nvarchar(30),
@SupplierPhone int,
@SupplierAddress nvarchar(50),
@SupplierJoinDate datetime2,
@SupplierRating decimal(1,1),
@SupplierCity nvarchar(15),
@SupplierProvince nvarchar(15),
@SupplierCountry nvarchar(15),
@SupplierPinCode int,
@SupplierDataLastUpdate datetime2
As
update [dbo].[Suppliers]
set
SupplierName=@SupplierName,
SupplierIndustry=@SupplierIndustry,
SupplierEmail=@SupplierEmail,
SupplierPhone=@SupplierPhone,
SupplierAddress=@SupplierAddress,
SupplierJoinDate=@SupplierJoinDate,
SupplierRating=@SupplierRating,
SupplierCity=@SupplierCity,
SupplierProvince=@SupplierProvince,
SupplierCountry=@SupplierCountry,
SupplierPinCode=@SupplierPinCode,
SupplierDataLastUpdate=@SupplierDataLastUpdate
where
SupplierId = @SupplierId
Go



/* Stored Procedure for Getting Suppliers */
create procedure Get_Suppliers
As
select * from [dbo].[Suppliers]
Go


/* Stored Procedure for Get Supplier By Id */
create procedure Get_Supplier_By_Id
@SupplierId int
As
select * from [dbo].[Suppliers] 
where SupplierId = @SupplierId
Go

/* Stored Procedure for Delete Supplier*/
create procedure Delete_Supplier
@SupplierId int
As
delete from [dbo].[Suppliers]
where SupplierId = @SupplierId
Go




