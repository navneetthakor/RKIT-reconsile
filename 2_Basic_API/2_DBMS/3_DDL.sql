-- DDL : Data Defination Language
-- used to define and manage structure of the data. 
-- Following are important queries related to DDL

	-- use my_test_schema;

# 1) CREATE : We already seen it

-- for table
CREATE TABLE Hello(
id int
);

create table Hello2(
id int primary key
);

-- for database
CREATE DATABASE my_test_schema;

# 2) DROP : to permenantly delete things

-- for tables
DROP TABLE Hello;

-- for database
DROP DATABASE my_test_schema;

# 3) ALTER : to modify things in database

-- adding column
ALTER TABLE Hello
ADD name VARCHAR(50);
	-- INSERT INTO Hello(id, name) values(1,"Navneet");
	-- select * from Hello;

 -- droping column
ALTER TABLE Hello
drop column name;

-- modify columns data type
alter table Hello
modify name text;

-- rename column
alter table Hello
change name user_name varchar(100);

-- adding primary key
alter table Hello
add primary key(id);

-- drop primary key
alter table Hello
drop primary key;

-- add foreign key
alter table Hello
add constraint   foreign key (id) references Hello2(id);

-- drop foreign key 
alter table Hello2
drop foreign key fk_constraint_name;

	-- show create table my_Hello;
    
-- change table name
alter table Hello
rename to my_Hello;

# 4) describe : describes structure of table
describe my_Hello; 

# 5) explain : explains execution plan for given query
use fsep_model;
explain 
select fname, project_info.title
 from student inner join project_info
 on student.pid = project_info.pid
 where student.college_guide_eid = 101; 

# 6) truncate : to remove all data from tables, but preserve structure, resets auto_increment counters
-- you may encounter errors if there are foreign keys associated with current table 
-- then either delete entries, remove fk_constraints, add on delete cascade property
use my_test_schema;
truncate table my_Hello;
 


