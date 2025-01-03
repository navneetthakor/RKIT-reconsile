-- TCL: Transaction control language
-- deals with transaction management in dataset

create schema my_test_schema;
use my_test_schema;

# 1) commit : to permanently save all the changes made durinjg the current transaction
-- by defualt all the statement are independent transactions

create table Hello(
id int primary key,
username text
);

insert into Hello values (1, "navneet");

-- use begin to treat group of statment as single transaction

begin;
create table Hello(
id int primary key,
username text
);

insert into Hello values (1, "navneet");
commit;

-- optaionlly 'set autocommit = 0;' this will now not trit each statement as seprate statement\
		-- -> so we not need to write begin statment
set autocommit = 0;

create table Hello(
id int primary key,
username text
);

insert into Hello values (1, "navneet");
commit;

# 2) rollback :p to undo all the changes made by the currentt transaction
begin;
create table Hello(
id int primary key,
username text
);

insert into Hello values (1, "navneet");
rollback;

# 3) savepoint : to set a point within a transaction that we can rollback to
begin;
create table Hello(
id int primary key,
username text
);
savepoint table_hello_created;

insert into Hello values (1, "navneet");
rollback to savepoint table_hello_created;
commit;

