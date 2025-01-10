-- Views : View = Saved Query
-- provides abstraction ans security
-- updation of view is depends on what type of view it is

# 1) create view
create view student_guid as
select 
	s.sid as student_sid, s.fname as student_fname, s.lname as student_lname,
    p.eid as professor_eid, p.fname as professor_fname, p.lname  as professor_lname
from
	student as s inner join professor as p
on
	s.college_guide_eid = p.eid;
    
#2) use view 
select * from student_guid;

# 2) to drop view 
DROP VIEW student_guid;

# 3) to modify view
create or replace view student_guid as
select 
	sid as student_id, s.fname as student_fname, s.lname as student_lname
from 
	student as s;
    
    
-- --------- Index --------------
create index student_emails on student(email);

show index from student;
select * from student;

drop index student_emails on student;