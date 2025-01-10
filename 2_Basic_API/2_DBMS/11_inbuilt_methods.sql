-- playing with string 
select concat('Hello', ' ', 'World');
select length('Hello World');
select trim('   Hello World   ');
select upper('hello world');
select lower('HELLO WORLD');
-- etc


-- Playing with numbers 
select abs(-421);
select round(42.50); -- 43
select round(42.49); -- 42
select round(42.3526);
select round(42.3526, 2);
select ceil(42.3526);
select floor(42.3526);

-- playing with date and time
select current_date(); -- 2025-01-10
select current_time(); -- 12:55:26
select now();	-- date and time both
select date(now()); -- 2025-01-10
select year(now()); -- 2025
select month(now()); -- 1
select day(now()); -- 10

-- jow with date_format
select date_format(now(), '%M'); -- January
select date_format(now(), '%D'); -- 10th
select date_format(now(), '%d'); -- 10
select date_format(now(), '%m'); -- 01
select date_format(now(), '%b'); -- Jan
select date_format(now(), '%j'); -- 010 (from 001 to 366)

show create table student;
show table status where name = "student";