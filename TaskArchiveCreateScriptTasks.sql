USE [TaskArchive]
GO

/****** Object:  Table [dbo].[Tasks]    Script Date: 17.04.2020 22:07:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[UserID] [nvarchar](50) NOT NULL,
	[CurrentCounter] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[TaskName] [nvarchar](200) NOT NULL,
	[TaskDescription] [nvarchar](max) NULL,
	[TaskFlag] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

