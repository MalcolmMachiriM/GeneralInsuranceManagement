USE [GeneralInsurance_ActiveDrive]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Users]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_UserAccountAuthorizationLog]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_UserAccountAuthorizationLog]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_UnderwritingQuestions]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_UnderwritingQuestions]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Titles]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_Titles]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_TimeGroups]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_TimeGroups]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_StopOrders]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_StopOrders]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_PaymentMethods]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_PaymentMethods]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Audit_History]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[sp_Save_Audit_History]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF_Users_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT IF EXISTS [DF_UserRoles_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT IF EXISTS [DF_UserRoles_StatusID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserAccountsAuthorizationLog]') AND type in (N'U'))
ALTER TABLE [dbo].[UserAccountsAuthorizationLog] DROP CONSTRAINT IF EXISTS [DF_UserAccountsAuthorizationLog_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaritalStatuses]') AND type in (N'U'))
ALTER TABLE [dbo].[MaritalStatuses] DROP CONSTRAINT IF EXISTS [DF__MaritalSt__DateM__02C769E9]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaritalStatuses]') AND type in (N'U'))
ALTER TABLE [dbo].[MaritalStatuses] DROP CONSTRAINT IF EXISTS [DF__MaritalSt__DateC__01D345B0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
ALTER TABLE [dbo].[Departments] DROP CONSTRAINT IF EXISTS [DF_Departments_DateCreated]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[UserAccountsAuthorizationLog]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[UserAccountsAuthorizationLog]
GO
/****** Object:  Table [dbo].[UnderwritingQuestions]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[UnderwritingQuestions]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Titles]
GO
/****** Object:  Table [dbo].[Timegroups]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Timegroups]
GO
/****** Object:  Table [dbo].[SysModules]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[SysModules]
GO
/****** Object:  Table [dbo].[StopOrderNames]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[StopOrderNames]
GO
/****** Object:  Table [dbo].[RequirementTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[RequirementTypes]
GO
/****** Object:  Table [dbo].[Religions]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Religions]
GO
/****** Object:  Table [dbo].[RelationTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[RelationTypes]
GO
/****** Object:  Table [dbo].[RecordUpdateTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[RecordUpdateTypes]
GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Qualifications]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[ProductCategory]
GO
/****** Object:  Table [dbo].[PremiumPaymentFrequencies]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[PremiumPaymentFrequencies]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[PaymentMethods]
GO
/****** Object:  Table [dbo].[Occupations]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Occupations]
GO
/****** Object:  Table [dbo].[MedicalRequirements]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[MedicalRequirements]
GO
/****** Object:  Table [dbo].[MaritalStatuses]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[MaritalStatuses]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Languages]
GO
/****** Object:  Table [dbo].[InterestRateTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[InterestRateTypes]
GO
/****** Object:  Table [dbo].[InterestRateFrequencies]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[InterestRateFrequencies]
GO
/****** Object:  Table [dbo].[InstitutionTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[InstitutionTypes]
GO
/****** Object:  Table [dbo].[IncomeTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[IncomeTypes]
GO
/****** Object:  Table [dbo].[IdentificationTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[IdentificationTypes]
GO
/****** Object:  Table [dbo].[HumanDemographicGroups]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[HumanDemographicGroups]
GO
/****** Object:  Table [dbo].[HabitsAndInterests]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[HabitsAndInterests]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Departments]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Currencies]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Countries]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Cities]
GO
/****** Object:  Table [dbo].[CategoryPackages]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[CategoryPackages]
GO
/****** Object:  Table [dbo].[BusinessDecisions]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[BusinessDecisions]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[Banks]
GO
/****** Object:  Table [dbo].[AuditHistory]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AuditHistory]
GO
/****** Object:  Table [dbo].[AuditDescription]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AuditDescription]
GO
/****** Object:  Table [dbo].[AuditActions]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AuditActions]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AddressTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AddressTypes]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[AccountTypes]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/12/2024 8:33:18 AM ******/
DROP TABLE IF EXISTS [dbo].[__MigrationHistory]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditActions]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditActions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditDescription]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditDescription](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditHistory]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ActionId] [int] NULL,
	[DateOfAction] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[Description] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[BankName] [varchar](100) NULL,
	[NumberOfBranches] [int] NULL,
	[AccountNumberLength] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessDecisions]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessDecisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryPackages]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryPackages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Package] [nvarchar](250) NULL,
	[ProcessTime] [int] NULL,
	[Retention] [decimal](18, 2) NULL,
	[SumAssuredBasis] [int] NULL,
	[EffectiveDate] [datetime] NULL,
	[MaxPremiumTerm] [int] NULL,
	[MinSumAssured] [decimal](18, 2) NULL,
	[MaxSumAssured] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Code] [varchar](20) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[Code] [varchar](50) NULL,
	[Rate] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HabitsAndInterests]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HabitsAndInterests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HumanDemographicGroups]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HumanDemographicGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentificationTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentificationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentificationTypeName] [varchar](100) NULL,
	[Format] [varchar](100) NULL,
	[MinimumLengthRequired] [int] NULL,
	[MaximumLengthRequired] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IncomeTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IncomeType] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_IncomeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InstitutionTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstitutionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterestRateFrequencies]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterestRateFrequencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterestRateTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterestRateTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaritalStatuses]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritalStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MaritalStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRequirements]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRequirements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Description] [varchar](100) NULL,
	[Tariff] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Occupations]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Method] [varchar](100) NULL,
	[Code] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[BankDetailsRequired] [bit] NULL,
	[MobileNumberRequired] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PremiumPaymentFrequencies]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PremiumPaymentFrequencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Frequency] [varchar](100) NULL,
	[Code] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[SchemeID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QualificationName] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Qualifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecordUpdateTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecordUpdateTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RecordUpdateTypes] PRIMARY KEY CLUSTERED 
(
	[Description] ASC,
	[ModuleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelationTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Religions]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Religions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Religions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequirementTypes]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequirementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StopOrderNames]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StopOrderNames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[EmployerName] [varchar](100) NULL,
	[EmployeeNumber] [int] NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysModules]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysModules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysModules] PRIMARY KEY CLUSTERED 
(
	[ModuleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timegroups]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timegroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnderwritingQuestions]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnderwritingQuestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionType] [nvarchar](max) NOT NULL,
	[QuestionDescription] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UnderwritingQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccountsAuthorizationLog]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccountsAuthorizationLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecordUpdateTypeID] [int] NOT NULL,
	[UserID] [int] NULL,
	[CurrentStatusID] [int] NOT NULL,
	[RequestStatusID] [int] NOT NULL,
	[RequestUpdateBy] [int] NULL,
	[DateCreated] [datetime] NULL,
	[ApprovalStatusID] [int] NULL,
	[ApprovalBy] [int] NULL,
	[ApprovalDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[StatusID] [int] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Firstnames] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[UserRoleID] [int] NULL,
	[DepartmentID] [int] NULL,
	[Password] [nvarchar](1000) NULL,
	[LastUsedPassword] [nvarchar](1000) NULL,
	[LastPasswordUpdatedOn] [date] NULL,
	[PasswordExpires] [bit] NULL,
	[AllowPasswordReuse] [bit] NULL,
	[PasswordLifeSpan] [numeric](5, 0) NULL,
	[StatusID] [int] NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[MaritalStatuses] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateCreated]
GO
ALTER TABLE [dbo].[MaritalStatuses] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateModified]
GO
ALTER TABLE [dbo].[UserAccountsAuthorizationLog] ADD  CONSTRAINT [DF_UserAccountsAuthorizationLog_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_StatusID]  DEFAULT ((1)) FOR [StatusID]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Audit_History]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Save_Audit_History] 
( 
	@UserId int = null,
	@ActionId int = null,
	@Description int = null
	,@CreatedBy int = null
	,@DateOfAction DateTime 
) 
AS 
INSERT INTO [AuditHistory](
	   [UserId]
      ,[ActionId]
      ,[Description]
      ,[CreatedBy]
	  ,[DateOfAction]
		) VALUES ( 

			@UserId
			,@ActionId
			,@Description
			,@CreatedBy
			,getdate()
		) 



		
/****** Object:  StoredProcedure [dbo].[ContributionsPortal_ins]    Script Date: 7/18/2023 3:23:42 PM ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_PaymentMethods]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_Save_PaymentMethods] 
( 
	@Id int = null output,  
	@Method nvarchar(max) = null, 
	@Code nvarchar(50) = null, 
	@BankDetailsRequired bit = null, 
	@MobileNumberRequired bit = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [PaymentMethods](
			[Method], 
			[Code], 
			[BankDetailsRequired], 
			[MobileNumberRequired], 
			[DateCreated]
		) VALUES ( 

			@Method, 
			@Code, 
			@BankDetailsRequired, 
			@MobileNumberRequired, 
			getDate()
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [PaymentMethods] SET  
			[Method]=@Method, 
			[Code]=@Code, 
			[BankDetailsRequired]=@BankDetailsRequired, 
			[MobileNumberRequired]=@MobileNumberRequired, 			
			[DateModified]=getDate()

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_StopOrders]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[sp_Save_StopOrders] 
( 
	@Id int = null output,  
	@Name nvarchar(max) = null,
	@EmployerName nvarchar(max) = null,
	@EmployeeNumber nvarchar(max) = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [StopOrderNames](
			[Name], 
			[EmployerName], 
			[EmployeeNumber], 
			[DateCreated]
		) VALUES ( 

			@Name, 
			@EmployerName, 
			@EmployeeNumber, 
			getDate()
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [StopOrderNames] SET  
			[Name]=@Name, 			
			[EmployerName]=@EmployerName, 			
			[EmployeeNumber]=@EmployeeNumber, 			
			[DateModified]=getDate()

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_TimeGroups]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[sp_Save_TimeGroups] 
( 
	@Id int = null output,  
	@Description nvarchar(max) = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [Timegroups](
			[Description], 
			[DateCreated]
		) VALUES ( 

			@Description, 
			getDate()
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [Timegroups] SET  
			[Description]=@Description, 			
			[DateModified]=getDate()

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Titles]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[sp_Save_Titles] 
( 
	@Id int = null output,  
	@Name nvarchar(max) = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [Titles](
			[Name], 
			[DateCreated]
		) VALUES ( 

			@Name, 
			getDate()
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [Titles] SET  
			[Name]=@Name, 			
			[DateModified]=getDate()

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_UnderwritingQuestions]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[sp_Save_UnderwritingQuestions] 
( 
	@Id int = null output,  
	@QuestionType nvarchar(max) = null, 
	@QuestionDescription nvarchar(max) = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [UnderwritingQuestions](
			[QuestionType], 
			[QuestionDescription], 
			[DateCreated]
		) VALUES ( 

			@QuestionType, 
			@QuestionDescription, 
			getDate()
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [UnderwritingQuestions] SET  
			[QuestionType]=@QuestionType, 
			[QuestionDescription]=@QuestionDescription, 			
			[DateModified]=getDate()

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_UserAccountAuthorizationLog]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Save_UserAccountAuthorizationLog] 
( 
	@ID int = null output,  
	@RecordUpdateTypeID int = null, 
	@UserID int = null, 
	@CurrentStatusID int = null, 
	@RequestStatusID int = null, 
	@RequestUpdateBy int = null, 
	@ApprovalStatusID int = null, 
	@ApprovalBy int = null, 
	@DateCreated datetime = null, 
	@ApprovalDate datetime = null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [UserAccountsAuthorizationLog](
			[RecordUpdateTypeID], 
			[UserID], 
			[CurrentStatusID], 
			[RequestStatusID], 
			[RequestUpdateBy], 
			[ApprovalStatusID], 
			[ApprovalBy], 
			[DateCreated], 
			[ApprovalDate]
		) VALUES ( 

			@RecordUpdateTypeID, 
			@UserID, 
			@CurrentStatusID, 
			@RequestStatusID, 
			@RequestUpdateBy, 
			@ApprovalStatusID, 
			@ApprovalBy, 
			getDate(), 
			@ApprovalDate
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [UserAccountsAuthorizationLog] SET  
			[RecordUpdateTypeID]=@RecordUpdateTypeID, 
			[UserID]=@UserID, 
			[CurrentStatusID]=@CurrentStatusID, 
			[RequestStatusID]=@RequestStatusID, 
			[RequestUpdateBy]=@RequestUpdateBy, 
			[ApprovalStatusID]=@ApprovalStatusID, 
			[ApprovalBy]=@ApprovalBy, 
			
			[ApprovalDate]=@ApprovalDate
		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UserAccountAuthorizationLogReturnTable 
 
	RETURN @ID 
 
END 
 
GO
/****** Object:  StoredProcedure [dbo].[sp_Save_Users]    Script Date: 2/12/2024 8:33:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Save_Users] 
( 
	@ID int = null output,  
	@LastPasswordUpdatedOn date = null, 
	@UserRoleID int = null, 
	@DepartmentID int = null, 
	@StatusID int = null, 
	@DateCreated datetime = null, 
	@PasswordExpires bit = null, 
	@AllowPasswordReuse bit = null, 
	@PasswordLifeSpan numeric = null, 
	@Username nvarchar(100) = null, 
	@Firstnames nvarchar(100) = null, 
	@Surname nvarchar(100) = null, 
	@Password nvarchar(1000) = null, 
	@LastUsedPassword nvarchar(10) = null,
	@CreatedBy int = null,

	@ContactNumber nvarchar(100)= null,
	@EmailAddress nvarchar(100)=null
) 
AS 
BEGIN 
 
	IF @ID IS NULL OR @ID <= 0 
	BEGIN 
		 
		SELECT @ID = NULL 
 
		INSERT INTO [Users](
			[LastPasswordUpdatedOn], 
			[UserRoleID], 
			[DepartmentID], 
			[StatusID], 
			[DateCreated], 
			[PasswordExpires], 
			[AllowPasswordReuse], 
			[PasswordLifeSpan], 
			[Username], 
			[Firstnames], 
			[Surname], 
			[Password], 
			[LastUsedPassword], 			[CreatedBy],[ContactNumber],[EmailAddress]
		) VALUES ( 

			@LastPasswordUpdatedOn, 
			@UserRoleID, 
			@DepartmentID, 
			@StatusID, 
			getDate(), 
			@PasswordExpires, 
			@AllowPasswordReuse, 
			@PasswordLifeSpan, 
			@Username, 
			@Firstnames, 
			@Surname, 
			@Password, 
			@LastUsedPassword, 
			@Createdby,@ContactNumber,@EmailAddress
		) 
	END 
	ELSE 
	BEGIN 
		UPDATE [Users] SET  
			[LastPasswordUpdatedOn]=@LastPasswordUpdatedOn, 
			[UserRoleID]=@UserRoleID, 
			[DepartmentID]=@DepartmentID, 
			[StatusID]=@StatusID, 			
			[PasswordExpires]=@PasswordExpires, 
			[AllowPasswordReuse]=@AllowPasswordReuse, 
			[PasswordLifeSpan]=@PasswordLifeSpan, 
			[Username]=@Username, 
			[Firstnames]=@Firstnames, 
			[Surname]=@Surname, 
			[Password]=@Password, 
			[LastUsedPassword]=@LastUsedPassword
			,[ContactNumber] = @ContactNumber,
			[EmailAddress] = @EmailAddress

		WHERE [ID]=@ID 
	END 
 
	SELECT @ID = ISNULL(@ID, SCOPE_IDENTITY()) 
	SELECT * FROM (SELECT @ID AS ReturnID) AS UsersReturnTable 
 
	RETURN @ID 
 
END 
 
GO
