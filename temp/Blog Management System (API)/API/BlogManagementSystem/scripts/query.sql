CREATE DATABASE BlogDB;


USE BlogDB;


CREATE TABLE blg01 (
    g01f01 INT AUTO_INCREMENT PRIMARY KEY Comment 'ID',         -- g01f01: Id (Primary Key)
    g01f02 VARCHAR(200) NOT NULL Comment 'Title',              	-- g01f02: Title
    g01f03 TEXT NOT NULL Comment 'Content',            			-- g01f03: Content
    g01f04 DATETIME NOT NULL Comment 'CreatedAt', 				-- g01f04: CreatedAt
    g01f05 DATETIME NULL Comment 'UpdatedAt'                    -- g01f05: UpdatedAt
);

drop table blg01;
Insert into blg01 values(0,'asdf','asdf','20250127','20250127');

select * from blg01;