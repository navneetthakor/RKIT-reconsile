-- Alias (as) : we can temporory infer table by some other name, use in self joins mostly


# 1) inner join
-- Q : list student with their corresponding company
select
	sid, fname, lname, name
from
	student as s inner join company as c
on
	s.cid = c.cid;
    
# 2) left outer join
select
	sid, fname, lname
from
	student as s left join company as c
on
	s.cid = c.cid;
    
# 3) right outre join
select
	sid, fname, lname
from
	student as s right join company as c
on
	s.cid = c.cid;
    
# 4) full outer join
-- there is no direct full outer join query in mysql
-- we can facilitate it with union of left and right join
select
	sid, fname, lname
from
	student as s left join company as c
on
	s.cid = c.cid
    
union

select
	sid, fname, lname
from
	student as s right join company as c
on
	s.cid = c.cid;