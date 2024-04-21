CREATE TABLE T_Account(
	[Id] Int PRIMARY KEY IDENTITY(1,1), -- identity = auto_increment 설정 (1,1) 1부터 시작해서 1씩 증가시킨다.
	[Name] VARCHAR(50),
	[Tel] INT,
);

--DROP TABLE IF EXISTS [dbo].[T_Account]

SELECT *
FROM [dbo].[T_Account]

SELECT COUNT(*) AS COUNT
FROM [dbo].[T_Account]

-- 컬럼 추가
ALTER TABLE [dbo].[T_Account] ADD [Age] INT

-- 컬럼 제거
ALTER TABLE [dbo].[T_Account] DROP COLUMN [Age]

-- INSERT
SET IDENTITY_INSERT T_Account ON

INSERT INTO [dbo].[T_Account]
(
	[Id],
	[Name],
	[Tel]
)
VALUES
(
	1,
	'LDH',
	1
)