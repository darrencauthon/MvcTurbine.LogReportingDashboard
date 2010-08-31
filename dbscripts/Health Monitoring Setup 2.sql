/****** Object: Table [dbo].[aspnet_WebEvent_ErrorCodes] Script Date: 07/29/2010 09:56:45 ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_ErrorCodes]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_WebEvent_ErrorCodes]
GO
/****** Object: Default [DF_aspnet_WebEvent_ErrorCodes_Level] Script Date: 07/29/2010 09:56:45 ******/
IF EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_aspnet_WebEvent_ErrorCodes_Level]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_ErrorCodes]'))
Begin
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_aspnet_WebEvent_ErrorCodes_Level]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[aspnet_WebEvent_ErrorCodes] DROP CONSTRAINT [DF_aspnet_WebEvent_ErrorCodes_Level]
END

End
GO
/****** Object: Table [dbo].[aspnet_WebEvent_ErrorCodes] Script Date: 07/29/2010 09:56:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_ErrorCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_WebEvent_ErrorCodes](
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [Name] [nvarchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
 [EventCode] [int] NOT NULL,
 [Level] [nvarchar](10) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_aspnet_WebEvent_ErrorCodes] PRIMARY KEY CLUSTERED
(
 [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ON
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (1, N'InvalidEventCode', -1, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (2, N'UndefinedEventCode/UndefinedEventDetailCode', 0, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (3, N'Not used', -9999, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (4, N'ApplicationCodeBase', 1000, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (5, N'ApplicationStart', 1001, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (6, N'ApplicationShutdown', 1002, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (7, N'ApplicationCompilationStart', 1003, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (8, N'ApplicationCompilationEnd', 1004, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (9, N'ApplicationHeartbeat', 1005, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (10, N'RequestCodeBase', 2000, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (11, N'RequestTransactionComplete', 2001, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (12, N'RequestTransactionAbort', 2002, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (13, N'ErrorCodeBase', 3000, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (14, N'RuntimeErrorRequestAbort', 3001, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (15, N'RuntimeErrorViewStateFailure', 3002, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (16, N'RuntimeErrorValidationFailure', 3003, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (17, N'RuntimeErrorPostTooLarge', 3004, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (18, N'RuntimeErrorUnhandledException', 3005, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (19, N'WebErrorParserError', 3006, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (20, N'WebErrorCompilationError', 3007, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (21, N'WebErrorConfigurationError', 3008, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (22, N'WebErrorOtherError', 3009, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (23, N'WebErrorPropertyDeserializationError', 3010, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (24, N'WebErrorObjectStateFormatterDeserializationError', 3011, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (25, N'AuditCodeBase', 4000, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (26, N'AuditFormsAuthenticationSuccess', 4001, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (27, N'AuditMembershipAuthenticationSuccess', 4002, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (28, N'AuditUrlAuthorizationSuccess', 4003, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (29, N'AuditFileAuthorizationSuccess', 4004, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (30, N'AuditFormsAuthenticationFailure', 4005, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (31, N'AuditMembershipAuthenticationFailure', 4006, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (32, N'AuditUrlAuthorizationFailure', 4007, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (33, N'AuditFileAuthorizationFailure', 4008, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (34, N'AuditInvalidViewStateFailure', 4009, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (35, N'AuditUnhandledSecurityException', 4010, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (36, N'AuditUnhandledAccessException', 4011, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (37, N'MiscCodeBase', 6000, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (38, N'WebEventProviderInformation', 6001, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (39, N'ApplicationDetailCodeBase', 50000, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (40, N'ApplicationShutdownUnknown', 50001, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (41, N'ApplicationShutdownHostingEnvironment', 50002, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (42, N'ApplicationShutdownChangeInGlobalAsax', 50003, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (43, N'ApplicationShutdownConfigurationChange', 50004, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (44, N'ApplicationShutdownUnloadAppDomainCalled', 50005, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (45, N'ApplicationShutdownChangeInSecurityPolicyFile', 50006, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (46, N'ApplicationShutdownBinDirChangeOrDirectoryRename', 50007, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (47, N'ApplicationShutdownBrowsersDirChangeOrDirectoryRename', 50008, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (48, N'ApplicationShutdownCodeDirChangeOrDirectoryRename', 50009, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (49, N'ApplicationShutdownResourcesDirChangeOrDirectoryRename', 50010, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (50, N'ApplicationShutdownIdleTimeout', 50011, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (51, N'ApplicationShutdownPhysicalApplicationPathChanged', 50012, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (52, N'ApplicationShutdownHttpRuntimeClose', 50013, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (53, N'ApplicationShutdownInitializationError', 50014, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (54, N'ApplicationShutdownMaxRecompilationsReached', 50015, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (55, N'StateServerConnectionError', 50016, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (56, N'AuditDetailCodeBase', 50200, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (57, N'InvalidTicketFailure', 50201, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (58, N'ExpiredTicketFailure', 50202, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (59, N'InvalidViewStateMac', 50203, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (60, N'InvalidViewState', 50204, N'Error')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (61, N'WebEventDetailCodeBase', 50300, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (62, N'SqlProviderEventsDropped', 50301, N'Info')
INSERT [dbo].[aspnet_WebEvent_ErrorCodes] ([Id], [Name], [EventCode], [Level]) VALUES (63, N'WebExtendedBase', 100000, N'Info')
SET IDENTITY_INSERT [dbo].[aspnet_WebEvent_ErrorCodes] OFF
/****** Object: Default [DF_aspnet_WebEvent_ErrorCodes_Level] Script Date: 07/29/2010 09:56:45 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_aspnet_WebEvent_ErrorCodes_Level]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_ErrorCodes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_aspnet_WebEvent_ErrorCodes_Level]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[aspnet_WebEvent_ErrorCodes] ADD CONSTRAINT [DF_aspnet_WebEvent_ErrorCodes_Level] DEFAULT ('Info') FOR [Level]
END

End
GO

CREATE VIEW vw_aspnet_WebEvents_extended
AS

SELECT
 webEvent.EventId
 , webEvent.EventTimeUtc
 , webEvent.EventTime
 , webEvent.EventType
 , webEvent.EventSequence
 , webEvent.EventOccurrence
 , webEvent.EventCode
 , webEvent.EventDetailCode
 , webEvent.Message
 , webEvent.ApplicationPath
 , webEvent.ApplicationVirtualPath
 , webEvent.MachineName
 , webEvent.RequestUrl
 , webEvent.ExceptionType
 , webEvent.Details
 , webEventCodes.Level
FROM
 dbo.aspnet_WebEvent_Events AS webEvent
INNER JOIN
 dbo.aspnet_WebEvent_ErrorCodes AS webEventCodes ON webEvent.EventCode = webEventCodes.EventCode