-- https://pyh8171.tistory.com/8

----------------------------------------------------------------------------------------------------------------------------
-- create, alter
CREATE TABLE Account (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Identity = auto_increment ���� (1,1) 1���� �����ؼ� 1�� ������Ų��.
    [Name] VARCHAR(50),
	Tel Int,
);

select count(*) as Count from account

-- �÷� �߰�
ALTER TABLE Account
ADD TestId INT;

select * from account

Alter table Account
DROP column Testid

--truncate
truncate table account

select * from account

drop table if exists account

-- COMMENT ON TABLE Account IS '���� ����';

-- �÷� �߰�
ALTER TABLE Account
ADD testadd INT;

select * from account


-- �÷� ����
ALTER TABLE Account
drop column testadd

select * from account where name = N'�ڿ�ȯ' and Email = N'%pypy%'

----------------------------------------------------------------------------------------------------------------------------

-- sql server���� ������ column�� autoincrement ������ �� �ִ� ����� ����.
--ALTER TABLE Account
--ALTER COLUMN Id INT IDENTITY(1,1);

----------------------------------------------------------------------------------------------------------------------------
-- create, drop index

CREATE INDEX idx_UniqueKeyTest ON Account (Country);
DROP INDEX idx_UniqueKeyTest ON Account;
-- drop table if exists account

----------------------------------------------------------------------------------------------------------------------------
--insert

set identity_insert account off; -- pk identity �ɾ�״��� ������ �ٲٸ� ���� ���� �� �ִ�.

insert into Account (Id, Name, Tel)
				values (1, '�ڿ�ȯ', 01027748171) -- values ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) �� ����ص� �ȴ�.

insert into Account ( Name, Tel)
				values ('����', 010),
				       ('�ſ�', 010)

insert into account values('�뼮', 010)

select * from account where name = N'�ڿ�ȯ' and UniqueKeyTest <5 --  ����ȭ

SELECT *
FROM account WITH(INDEX(idx_UniqueKeyTest))
WHERE name = N'�ڿ�ȯ' AND UniqueKeyTest < 5; -- ����ȭ ���� �ʰ� �ε��� ����

----------------------------------------------------------------------------------------------------------------------------

insert into account (Id, name, email, country, UniqueKeyTest)
				values (1, '�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) -- values ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) �� ����ص� �ȴ�.

insert into account (name, email, country, UniqueKeyTest)
				values ('��ſ�', 'hsy', 'kr', 1)

----------------------------------------------------------------------------------------------------------------------------

DECLARE @Counter INT = 1;

WHILE @Counter <= 50000
BEGIN
    INSERT INTO Account (Name, Email, Country, UniqueKeyTest)
    VALUES ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', @Counter);

    SET @Counter = @Counter + 1;
END;

select * from account where name = N'�ڿ�ȯ' and UniqueKeyTest <5 --  ����ȭ

--truncate
truncate table account
----------------------------------------------------------------------------------------------------------------------------


insert into account (name, email, country, UniqueKeyTest)
				values ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) -- values ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) �� ����ص� �ȴ�.

-- index scan
select * from account where name = N'�ڿ�ȯ' and UniqueKeyTest <5 --  ����ȭ

-- fullscan
SELECT *
FROM account WITH(INDEX(idx_UniqueKeyTest))
WHERE name = N'�ڿ�ȯ' AND UniqueKeyTest < 5; -- ����ȭ ���� �ʰ� �ε��� ����

----------------------------------------------------------------------------------------------------------------------------

insert into account (Id, name, email, country, UniqueKeyTest)
				values (1, '�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) -- values ('�ڿ�ȯ', 'pypy8171@naver.com', 'kr', 1) �� ����ص� �ȴ�.

insert into account (name, email, country, UniqueKeyTest)
				values ('��ſ�', 'hsy', 'kr', 1)

----------------------------------------------------------------------------------------------------------------------------

select * from Account

----------------------------------------------------------------------------------------------------------------------------

UPDATE Account
SET UniqueKeyTest = 2
WHERE Name = '�ڿ�ȯ';

select * from Account

delete account
where name = '�ڿ�ȯ'

----------------------------------------------------------------------------------------------------------------------------

-- account ���̺��� �ε��� ���� ��ȸ
SELECT 
    OBJECT_NAME(i.object_id) AS TableName,
    i.name AS IndexName,
    i.type_desc AS IndexType,
    c.name AS ColumnName
FROM 
    sys.indexes AS i
INNER JOIN 
    sys.index_columns AS ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
INNER JOIN 
    sys.columns AS c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE 
    OBJECT_NAME(i.object_id) = 'account';

----------------------------------------------------------------------------------------------------------------------------

-- DDL (Data Definition Language):
-- ������ ���� ����, �����ͺ��̽��� ������ �����ϰų� �����ϴ� �� ���˴ϴ�. �ֿ� ��ɾ�� ������ ���Ե˴ϴ�:
-- CREATE: �����ͺ��̽� ��ü�� �����մϴ�.
-- ALTER: �����ͺ��̽� ��ü�� �����մϴ�.
-- DROP: �����ͺ��̽� ��ü�� �����մϴ�.
-- TRUNCATE: ���̺��� ��� �����͸� �����մϴ�.
-- COMMENT: �����ͺ��̽� ��ü�� ���� �ּ��� �߰��մϴ�.


-- DML (Data Manipulation Language):
-- ������ ���� ����, �����͸� �˻�, ����, ���� �Ǵ� �����ϴ� �� ���˴ϴ�. �ֿ� ��ɾ�� ������ ���Ե˴ϴ�:
-- SELECT: �����ͺ��̽����� �����͸� �˻��մϴ�.
-- INSERT: �����͸� �����ͺ��̽��� �����մϴ�.
-- UPDATE: �����ͺ��̽��� ���� �����͸� �����մϴ�.
-- DELETE: �����ͺ��̽����� �����͸� �����մϴ�.