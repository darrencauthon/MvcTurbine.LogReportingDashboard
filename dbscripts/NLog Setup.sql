CREATE TABLE [dbo].[NLog_Error](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[time_stamp] [datetime] NOT NULL,
	[host] [nvarchar](max) NOT NULL,
	[type] [nvarchar](300) NOT NULL,
	[source] [nvarchar](300) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[level] [nvarchar](300) NOT NULL,
	[logger] [nvarchar](300) NOT NULL,
	[stacktrace] [nvarchar](max) NOT NULL,
	[allxml] [ntext] NOT NULL,
 CONSTRAINT [PK_NLogError] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[NLog_Error] ADD  CONSTRAINT [DF_NLogError_time_stamp]  DEFAULT (getdate()) FOR [time_stamp]
GO
