CREATE TABLE T_Account(
	[Id] Int PRIMARY KEY IDENTITY(1,1), -- identity = auto_increment ���� (1,1) 1���� �����ؼ� 1�� ������Ų��.
	[Name] VARCHAR(50),
	[Tel] INT,
);

--DROP TABLE IF EXISTS [dbo].[T_Account]

SELECT *
FROM [dbo].[T_Account]

SELECT COUNT(*) AS COUNT
FROM [dbo].[T_Account]

-- �÷� �߰�
ALTER TABLE [dbo].[T_Account] ADD [Age] INT

-- �÷� ����
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