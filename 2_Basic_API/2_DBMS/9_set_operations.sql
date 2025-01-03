-- type of column and number of clumns must be same

# 1) uinon

select
	sid, fname, lname
from
	student
where
	student.cid = 1
    
union

select
	sid, fname, lname
from
	student
where
	student.cid = 2;
    
# 2) uinon all
select
	sid, fname, lname
from
	student
where
	student.cid = 1
    
union all

select
	sid, fname, lname
from
	student
where
	student.cid = 2;
    
# 3) intersect
-- sql doesn't provide 'intersect' defualt
select 
	fname, lname
from
	student as s
where s.college_guide_eid in 
	(	select 
			eid
		from 
			professor as p
		where
			p.fname like '_a%');
            
# 4) except
-- sql doesn't provide 'except' defualt
select 
	fname, lname
from
	student as s
where s.college_guide_eid not in 
	(	select 
			eid
		from 
			professor as p
		where
			p.fname like '_a%');

