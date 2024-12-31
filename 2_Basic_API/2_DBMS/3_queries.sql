select fname as first_name
from student
where college_guide_eid = 101;

select student.sid, fname, lname, mid1_suggestions
from student inner join assesment
on student.sid = assesment.sid
where assesment.mid1_status = 1;


