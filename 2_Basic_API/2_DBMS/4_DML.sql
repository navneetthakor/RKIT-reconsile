-- DML : Data Manipulation Language

use my_test_schema; 

# 1) select
-- to retrive data

select * 
from hello;

select * 
from fsep_model.student;

# 2) update
-- to modify existing records in database table

-- adding data for illustration
insert into hello values(1);
insert into my_hello values(1, "navneet");

update my_hello
set user_name = "NavneetKumar"
where id = 1;

select * from my_hello;

# 3) delete
-- to remove records form a table
-- 'truncate' is more efficient as it not leaves logs but, it not allow condition
delete from my_hello
where id = 1;

# 4) insert 
-- already seen

