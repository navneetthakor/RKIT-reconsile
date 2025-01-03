use fsep_model;

# 1) between 
select
	sid, fname, lname, branch_name
from
	student
where
	sid between 1 and 5;
    
# 2) in, not in
-- it excepts tuple of values 
select
	sid, fname
from
	student
where
	college_guide_eid in (101,103);
    -- college_guide_eid not in (101,103);

# 3) checking for null
-- we can't use relational operators here
select
	sid, fname
from
	student
where
	email is null;
	-- email is not null;
    
# 4) order by
select 
	sid, fname, lname
from
	student
where lower(branch_name) in ('ahmedabad')
order by lname ASC, lname DESC;

# 5) group by, having
-- having is like 'where' clause for groups
-- use for aggrigates
select
	sid, fname, count(*) as count
from
	student
group by 
	branch_name
having
	count(*) > 1;
    
-- aggrigate functions
-- count, sum, avg; : only for numerical values
-- min, max : data types which have order like : int, float, varchar etc.. 
