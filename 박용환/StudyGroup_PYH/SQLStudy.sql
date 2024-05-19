-- https://pyh8171.tistory.com/8

----------------------------------------------------------------------------------------------------------------------------
-- create, alter
CREATE TABLE Account (
    Id INT PRIMARY KEY IDENTITY(1,1), -- Identity = auto_increment 설정 (1,1) 1부터 시작해서 1씩 증가시킨다.
    [Name] VARCHAR(50),
	Tel Int,
);

select count(*) as Count from account

-- 컬럼 추가
ALTER TABLE Account
ADD TestId INT;

select * from account

Alter table Account
DROP column Testid

--truncate
truncate table account

select * from account

drop table if exists account

-- COMMENT ON TABLE Account IS '계정 정보';

-- 컬럼 추가
ALTER TABLE Account
ADD testadd INT;

select * from account


-- 컬럼 제거
ALTER TABLE Account
drop column testadd

select * from account where name = N'박용환' and Email = N'%pypy%'

----------------------------------------------------------------------------------------------------------------------------

-- sql server에서 생성한 column에 autoincrement 설정할 수 있는 방법은 없다.
--ALTER TABLE Account
--ALTER COLUMN Id INT IDENTITY(1,1);

----------------------------------------------------------------------------------------------------------------------------
-- create, drop index

CREATE INDEX idx_UniqueKeyTest ON Account (Country);
DROP INDEX idx_UniqueKeyTest ON Account;
-- drop table if exists account

----------------------------------------------------------------------------------------------------------------------------
--insert

set identity_insert account off; -- pk identity 걸어뒀더라도 설정을 바꾸면 직접 넣을 수 있다.

insert into Account (Id, Name, Tel)
				values (1, '박용환', 01027748171) -- values ('박용환', 'pypy8171@naver.com', 'kr', 1) 만 사용해도 된다.

insert into Account ( Name, Tel)
				values ('동희', 010),
				       ('신영', 010)

insert into account values('용석', 010)

select * from account where name = N'박용환' and UniqueKeyTest <5 --  최적화

SELECT *
FROM account WITH(INDEX(idx_UniqueKeyTest))
WHERE name = N'박용환' AND UniqueKeyTest < 5; -- 최적화 하지 않고 인덱스 강제

----------------------------------------------------------------------------------------------------------------------------

insert into account (Id, name, email, country, UniqueKeyTest)
				values (1, '박용환', 'pypy8171@naver.com', 'kr', 1) -- values ('박용환', 'pypy8171@naver.com', 'kr', 1) 만 사용해도 된다.

insert into account (name, email, country, UniqueKeyTest)
				values ('허신영', 'hsy', 'kr', 1)

----------------------------------------------------------------------------------------------------------------------------

DECLARE @Counter INT = 1;

WHILE @Counter <= 50000
BEGIN
    INSERT INTO Account (Name, Email, Country, UniqueKeyTest)
    VALUES ('박용환', 'pypy8171@naver.com', 'kr', @Counter);

    SET @Counter = @Counter + 1;
END;

select * from account where name = N'박용환' and UniqueKeyTest <5 --  최적화

--truncate
truncate table account
----------------------------------------------------------------------------------------------------------------------------


insert into account (name, email, country, UniqueKeyTest)
				values ('박용환', 'pypy8171@naver.com', 'kr', 1) -- values ('박용환', 'pypy8171@naver.com', 'kr', 1) 만 사용해도 된다.

-- index scan
select * from account where name = N'박용환' and UniqueKeyTest <5 --  최적화

-- fullscan
SELECT *
FROM account WITH(INDEX(idx_UniqueKeyTest))
WHERE name = N'박용환' AND UniqueKeyTest < 5; -- 최적화 하지 않고 인덱스 강제

----------------------------------------------------------------------------------------------------------------------------

insert into account (Id, name, email, country, UniqueKeyTest)
				values (1, '박용환', 'pypy8171@naver.com', 'kr', 1) -- values ('박용환', 'pypy8171@naver.com', 'kr', 1) 만 사용해도 된다.

insert into account (name, email, country, UniqueKeyTest)
				values ('허신영', 'hsy', 'kr', 1)

----------------------------------------------------------------------------------------------------------------------------

select * from Account

----------------------------------------------------------------------------------------------------------------------------

UPDATE Account
SET UniqueKeyTest = 2
WHERE Name = '박용환';

select * from Account

delete account
where name = '박용환'

----------------------------------------------------------------------------------------------------------------------------

-- account 테이블의 인덱스 정보 조회
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
-- 데이터 정의 언어로, 데이터베이스의 구조를 정의하거나 변경하는 데 사용됩니다. 주요 명령어에는 다음이 포함됩니다:
-- CREATE: 데이터베이스 객체를 생성합니다.
-- ALTER: 데이터베이스 객체를 변경합니다.
-- DROP: 데이터베이스 객체를 삭제합니다.
-- TRUNCATE: 테이블의 모든 데이터를 삭제합니다.
-- COMMENT: 데이터베이스 객체에 대한 주석을 추가합니다.


-- DML (Data Manipulation Language):
-- 데이터 조작 언어로, 데이터를 검색, 삽입, 수정 또는 삭제하는 데 사용됩니다. 주요 명령어에는 다음이 포함됩니다:
-- SELECT: 데이터베이스에서 데이터를 검색합니다.
-- INSERT: 데이터를 데이터베이스에 삽입합니다.
-- UPDATE: 데이터베이스의 기존 데이터를 수정합니다.
-- DELETE: 데이터베이스에서 데이터를 삭제합니다.