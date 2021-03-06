USE [DocManage]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[MineID] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[SubGroupID] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mines]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mines](
	[MineID] [int] IDENTITY(1,1) NOT NULL,
	[MineName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Mines] PRIMARY KEY CLUSTERED 
(
	[MineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PdfFiles]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PdfFiles](
	[PdfFileID] [int] IDENTITY(1,1) NOT NULL,
	[PdfFileName] [nvarchar](200) NOT NULL,
	[GroupID] [int] NOT NULL,
	[SubGroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[PdfFileUrl] [nvarchar](max) NULL,
	[CreateON] [datetime2](7) NULL,
	[UpdateON] [datetime2](7) NULL,
 CONSTRAINT [PK_PdfFiles] PRIMARY KEY CLUSTERED 
(
	[PdfFileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PDFs]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PDFs](
	[PDFID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[GroupID] [int] NOT NULL,
	[SubGroupID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[PDFName] [nvarchar](max) NULL,
	[CreateON] [datetime2](7) NULL,
	[UpdateON] [datetime2](7) NULL,
 CONSTRAINT [PK_PDFs] PRIMARY KEY CLUSTERED 
(
	[PDFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SentEmailList]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentEmailList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Emailid] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[SentDateTime] [datetime2](7) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
 CONSTRAINT [PK_SentEmailList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDetails]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetails](
	[StockDetailID] [int] IDENTITY(1,1) NOT NULL,
	[StockMainID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemName] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[Unit] [nvarchar](max) NULL,
	[LastBalQty] [decimal](18, 2) NOT NULL,
	[PurchaseQty] [decimal](18, 2) NOT NULL,
	[SaleQty] [decimal](18, 2) NOT NULL,
	[StockQty] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_StockDetails] PRIMARY KEY CLUSTERED 
(
	[StockDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItems]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItems](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[ItemGroup] [nvarchar](max) NOT NULL,
	[Unit] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StockItems] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockMains]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockMains](
	[StockMainID] [int] IDENTITY(1,1) NOT NULL,
	[MonthYear] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[StockAmt] [decimal](18, 2) NOT NULL,
	[DebtorAmt] [decimal](18, 2) NOT NULL,
	[StockDebtTot] [decimal](18, 2) NOT NULL,
	[CreditorAmt] [decimal](18, 2) NOT NULL,
	[CredTot] [decimal](18, 2) NOT NULL,
	[DebitBal70] [decimal](18, 2) NOT NULL,
	[BankDebitAmt] [decimal](18, 2) NOT NULL,
	[ExcessDB] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_StockMains] PRIMARY KEY CLUSTERED 
(
	[StockMainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubGroups]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubGroups](
	[SubGroupID] [int] IDENTITY(1,1) NOT NULL,
	[SubGroupName] [nvarchar](50) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_SubGroups] PRIMARY KEY CLUSTERED 
(
	[SubGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEmail]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEmail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Emailid] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserEmail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Mines_MineID] FOREIGN KEY([MineID])
REFERENCES [dbo].[Mines] ([MineID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Mines_MineID]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Groups_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Groups_GroupID]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_SubGroups_SubGroupID] FOREIGN KEY([SubGroupID])
REFERENCES [dbo].[SubGroups] ([SubGroupID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_SubGroups_SubGroupID]
GO
ALTER TABLE [dbo].[PdfFiles]  WITH CHECK ADD  CONSTRAINT [FK_PdfFiles_Groups_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[PdfFiles] CHECK CONSTRAINT [FK_PdfFiles_Groups_GroupID]
GO
ALTER TABLE [dbo].[PdfFiles]  WITH CHECK ADD  CONSTRAINT [FK_PdfFiles_Items_ItemID] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[PdfFiles] CHECK CONSTRAINT [FK_PdfFiles_Items_ItemID]
GO
ALTER TABLE [dbo].[PdfFiles]  WITH CHECK ADD  CONSTRAINT [FK_PdfFiles_SubGroups_SubGroupID] FOREIGN KEY([SubGroupID])
REFERENCES [dbo].[SubGroups] ([SubGroupID])
GO
ALTER TABLE [dbo].[PdfFiles] CHECK CONSTRAINT [FK_PdfFiles_SubGroups_SubGroupID]
GO
ALTER TABLE [dbo].[PDFs]  WITH CHECK ADD  CONSTRAINT [FK_PDFs_Groups_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[PDFs] CHECK CONSTRAINT [FK_PDFs_Groups_GroupID]
GO
ALTER TABLE [dbo].[PDFs]  WITH CHECK ADD  CONSTRAINT [FK_PDFs_Items_ItemID] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[PDFs] CHECK CONSTRAINT [FK_PDFs_Items_ItemID]
GO
ALTER TABLE [dbo].[PDFs]  WITH CHECK ADD  CONSTRAINT [FK_PDFs_SubGroups_SubGroupID] FOREIGN KEY([SubGroupID])
REFERENCES [dbo].[SubGroups] ([SubGroupID])
GO
ALTER TABLE [dbo].[PDFs] CHECK CONSTRAINT [FK_PDFs_SubGroups_SubGroupID]
GO
ALTER TABLE [dbo].[SubGroups]  WITH CHECK ADD  CONSTRAINT [FK_SubGroups_Groups_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[SubGroups] CHECK CONSTRAINT [FK_SubGroups_Groups_GroupID]
GO
/****** Object:  StoredProcedure [dbo].[StockDetailsSP]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Manit Soni
-- Create date: 08/08/2021
-- Description:	For Stock Details
-- =============================================
CREATE PROCEDURE [dbo].[StockDetailsSP]							
(									
@smid int									
)									
AS BEGIN									
SELECT m.StockMainID,m.Date,m.StockAmt,d.ItemName,m.MonthYear,d.GroupName,d.Unit,d.LastBalQty,d.PurchaseQty,d.SaleQty,d.StockQty,d.Rate,d.Amount									
FROM StockMains m 									
INNER JOIN StockDetails d ON m.StockMainID=d.StockMainID									
WHERE m.StockMainID=@smid									
END									
GO
/****** Object:  StoredProcedure [dbo].[StockMainsSP]    Script Date: 17-08-2021 23:30:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Manit Soni
-- Create date: 08/08/2021
-- Description:	For Stock Mains
-- =============================================
Create PROCEDURE [dbo].[StockMainsSP]																				
(																						
@smid int																						
)																						
AS																						
BEGIN																						
select pr.StockMainID,pr.Date,pr.CreditorAmt,pr.DebtorAmt,CAST(ISNULL(pr.StockAmt + pr.DebtorAmt,0)AS decimal(18,2)) AS TotalAmt,																						
CAST(ISNULL(pr.StockAmt + pr.DebtorAmt -pr.CreditorAmt,0)AS decimal(18,2)) AS TotLesCredAmt,																						
CAST(ISNULL((pr.DebtorAmt - pr.CreditorAmt) * 30 / 100,0)AS decimal(18,2)) AS Creditor30,																						
CAST(ISNULL((pr.DebtorAmt - pr.CreditorAmt) * 70 / 100,0)AS decimal(18,2)) AS Creditor70,																						
		(select  CAST(ISNULL(SUM(d.Amount),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Raw Material' AND m.StockMainID=@smid) RawMaterial,																				
		(select CAST(ISNULL(SUM(d.Amount),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Finished Goods' AND m.StockMainID=@smid) FinishedGoods,																				
		(select CAST(ISNULL(SUM(d.Amount),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Other Inventory' AND m.StockMainID=@smid ) OtherInventory,																				
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Raw Material' AND m.StockMainID=@smid) RawMaterial25,																				
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Raw Material' AND m.StockMainID=@smid) RawMaterial75,																				
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Finished Goods' AND m.StockMainID=@smid) FinishedGoods25,																				
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Finished Goods' AND m.StockMainID=@smid) FinishedGoods75,																				
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Other Inventory' AND m.StockMainID=@smid) OtherInventory25,																				
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Other Inventory' AND m.StockMainID=@smid) OtherInventory75,																				
																						
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Raw Material' AND m.StockMainID=@smid)+																				
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Finished Goods' AND m.StockMainID=@smid)+																				
		(select CAST(ISNULL(SUM(d.Amount * 25 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Other Inventory' AND m.StockMainID=@smid)+																				
		CAST(ISNULL((pr.DebtorAmt - pr.CreditorAmt) * 30 / 100,0)AS decimal(18,2)) TotalAmt25,																				
																						
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Raw Material' AND m.StockMainID=@smid)+																				
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Finished Goods' AND m.StockMainID=@smid)+																				
		(select CAST(ISNULL(SUM(d.Amount * 75 /100),0)AS decimal(18,2))from StockDetails d INNER JOIN StockMains m ON d.StockMainID=m.StockMainID where d.GroupName='Other Inventory' AND m.StockMainID=@smid)+																				
		CAST(ISNULL((pr.DebtorAmt - pr.CreditorAmt) * 70 / 100,0)AS decimal(18,2)) TotalAmt75																				
																						
																						
from StockMains pr where pr.StockMainID=@smid																						
END																						
GO
