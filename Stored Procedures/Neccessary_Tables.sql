-- /* Creating Table for ITems*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](40) NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemPrice] [float] NOT NULL,
	[ItemCreationDate] [datetime2](7) NOT NULL,
	[ItemLastUpdate] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- /*Creating Table for Suppliers*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](40) NOT NULL,
	[SupplierIndustry] [nvarchar](40) NOT NULL,
	[SupplierEmail] [nvarchar](30) NOT NULL,
	[SupplierPhone] [bigint] NOT NULL,
	[SupplierAddress] [nvarchar](50) NOT NULL,
	[SupplierJoinDate] [datetime2](7) NOT NULL,
	[SupplierRating] [decimal](2, 1) NULL,
	[SupplierCity] [nvarchar](15) NOT NULL,
	[SupplierProvince] [nvarchar](15) NOT NULL,
	[SupplierCountry] [nvarchar](15) NOT NULL,
	[SupplierPinCode] [int] NOT NULL,
	[SupplierDataLastUpdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK__Sellers__7FE3DB81B6CD3917] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Sellers__55F828C0BA48EFA2] UNIQUE NONCLUSTERED 
(
	[SupplierEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Sellers__6ACE4385F1CB9AD5] UNIQUE NONCLUSTERED 
(
	[SupplierPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Creating Table for Purchased items
/****** Object:  Table [dbo].[PurchasedItems]    Script Date: 1/20/2022 11:29:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PurchasedItems](
	[PurchaseItemsId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseInvoiceNumber] [nvarchar](40) NOT NULL,
	[ItemName] [nvarchar](40) NOT NULL,
	[Itemprice] [float] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemSupplierId] [int] NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
 CONSTRAINT [PK__Purchase__F9A1559DD06C3E82] PRIMARY KEY CLUSTERED 
(
	[PurchaseItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


-- Creating table for Purchased Orders
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PurchaseOrders](
	[PurchaseOrderID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [datetime2](7) NOT NULL,
	[PurchaseTotalPrice] [float] NOT NULL,
	[PurchaseInvoiceNumber] [nvarchar](40) NOT NULL,
	[PurchaseTransactionID] [nvarchar](40) NOT NULL,
	[PurchaseCourierCharge] [float] NOT NULL,
UNIQUE NONCLUSTERED 
(
	[PurchaseTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PurchaseInvoiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Creating Table for SellOrders
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SellOrders](
	[SellOrderID] [int] IDENTITY(1,1) NOT NULL,
	[SellDate] [datetime2](7) NOT NULL,
	[CustomerName] [nvarchar](40) NOT NULL,
	[CustomerPhone] [bigint] NOT NULL,
	[CustomerEmail] [nvarchar](30) NOT NULL,
	[SellTotalPrice] [float] NOT NULL,
	[SellInvoiceNumber] [nvarchar](40) NOT NULL,
	[SellTransactionID] [nvarchar](40) NOT NULL,
	[SellCourierCharge] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SellOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Creating table for SOLDitems
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SoldItems](
	[SoldItemsId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](40) NOT NULL,
	[ItemPrice] [float] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[SellOrderID] [int] NULL,
	[SellInvoiceNumber] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SoldItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SoldItems]  WITH CHECK ADD FOREIGN KEY([SellOrderID])
REFERENCES [dbo].[SellOrders] ([SellOrderID])
GO







-- Table Types Required to be Created : purchased Cart items

/****** Object:  UserDefinedTableType [dbo].[CartItemsType2]    Script Date: 1/20/2022 11:32:37 PM ******/
CREATE TYPE [dbo].[CartItemsType2] AS TABLE(
	[PurchaseInvoiceNumber] [nvarchar](40) NULL,
	[ItemName] [nvarchar](40) NULL,
	[ItemPrice] [float] NULL,
	[ItemQuantity] [int] NULL,
	[ItemSupplierId] [int] NULL,
	[PurchaseOrderID] [int] NULL
)
GO

/****** Object:  UserDefinedTableType [dbo].[SoldCartItemsType]    Script Date: 1/20/2022 11:33:23 PM ******/
CREATE TYPE [dbo].[SoldCartItemsType] AS TABLE(
	[SellInvoiceNumber] [nvarchar](40) NULL,
	[ItemName] [nvarchar](40) NULL,
	[ItemPrice] [float] NULL,
	[ItemQuantity] [int] NULL,
	[SellOrderID] [int] NULL
)
GO