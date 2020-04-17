USE [TodoRun]
GO

/****** Object:  Table [dbo].[Tasks]    Script Date: 17.04.2020 22:05:58 ******/
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
	[TaskFlag] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CurrentCounter] ASC,
	[StartDate] ASC,
	[TaskName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

