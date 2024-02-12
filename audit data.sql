USE [GeneralInsurance_ActiveDrive]
GO
SET IDENTITY_INSERT [dbo].[AuditActions] ON 
GO
INSERT [dbo].[AuditActions] ([ID], [Action]) VALUES (1, N'CREATE')
GO
INSERT [dbo].[AuditActions] ([ID], [Action]) VALUES (2, N'UPDATE')
GO
INSERT [dbo].[AuditActions] ([ID], [Action]) VALUES (3, N'DELETE')
GO
INSERT [dbo].[AuditActions] ([ID], [Action]) VALUES (4, N'LOGIN')
GO
SET IDENTITY_INSERT [dbo].[AuditActions] OFF
GO
SET IDENTITY_INSERT [dbo].[AuditDescription] ON 
GO
INSERT [dbo].[AuditDescription] ([ID], [Description]) VALUES (1, N'SUCCESS')
GO
INSERT [dbo].[AuditDescription] ([ID], [Description]) VALUES (2, N'FAIL')
GO
SET IDENTITY_INSERT [dbo].[AuditDescription] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([ID], [DepartmentName], [DateCreated], [CreatedBy]) VALUES (1, N'IT', CAST(N'2024-02-12T11:51:16.613' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([ID], [DepartmentName], [DateCreated], [CreatedBy]) VALUES (2, N'Accounts', CAST(N'2024-02-12T11:51:28.890' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (1, N'Admin', 1, CAST(N'2024-02-12T11:40:44.523' AS DateTime), 1)
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (2, N'Manager', 1, CAST(N'2024-02-12T11:41:44.880' AS DateTime), 1)
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (3, N'Broker', 1, CAST(N'2024-02-12T11:43:00.913' AS DateTime), 1)
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (4, N'Supervisor', 1, CAST(N'2024-02-12T11:43:10.990' AS DateTime), 1)
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (5, N'Clerk', 1, CAST(N'2024-02-12T11:43:27.517' AS DateTime), 1)
GO
INSERT [dbo].[UserRoles] ([ID], [Description], [StatusID], [DateCreated], [CreatedBy]) VALUES (6, N'Operations Clerk', 1, CAST(N'2024-02-12T11:43:38.717' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
