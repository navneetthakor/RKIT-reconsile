INSERT INTO company (cid, name)
VALUES
(1, 'RKIT'),
(2, 'Tech Mahindra'),
(3, 'Infosys'),
(4, 'Wipro'),
(5, 'TCS'),
(6, 'L&T Infotech'),
(7, 'Cygnet Infotech'),
(8, 'Persistent Systems'),
(9, 'Mindtree'),
(10, 'Capgemini');

INSERT INTO company_branch_info (cid, branch_name, address, mobile, email)
VALUES
(1, 'Ahmedabad', 'RKIT, SG Highway, Ahmedabad', '9876543210', 'info@rkit.edu.in'),
(1, 'Rajkot', 'RKIT house, near bhagti nagar railway station, Rajkot', '9876543210', 'info@rkit.edu.in'),
(2, 'Ahmedabad', 'Tech Mahindra, Prahlad Nagar, Ahmedabad', '9823456789', 'ahmedabad@techm.com'),
(3, 'Ahmedabad', 'Infosys, GIFT City, Ahmedabad', '9812345678', 'ahmedabad@infosys.com'),
(4, 'Ahmedabad', 'Wipro IT Park, SG Highway, Ahmedabad', '9123456780', 'info@wipro.com'),
(5, 'Gandhinagar', 'TCS Office, GIFT City, Gandhinagar', '9123456781', 'info@tcs.com'),
(6, 'Ahmedabad', 'L&T Infotech, Prahlad Nagar, Ahmedabad', '9123456782', 'info@lntinfotech.com'),
(7, 'Ahmedabad', 'Cygnet Infotech, Iscon Road, Ahmedabad', '9123456783', 'info@cygnet.com'),
(8, 'Ahmedabad', 'Persistent Systems, Ellisbridge, Ahmedabad', '9123456784', 'info@persistent.com'),
(9, 'Ahmedabad', 'Mindtree IT Park, Satellite, Ahmedabad', '9123456785', 'info@mindtree.com'),
(10, 'Gandhinagar', 'Capgemini Office, GIFT City, Gandhinagar', '9123456786', 'info@capgemini.com');

INSERT INTO project_info (pid, title, info, type, cid)
VALUES
(1, 'IoT Smart Agriculture', 'IoT-enabled system for smart irrigation', 'IoT', 1),
(2, 'AI-Based Student Monitoring', 'AI system to monitor student activities', 'AI', 1),
(3, 'E-Commerce Platform', 'A scalable platform for online shopping', 'Web Development', 1),
(4, 'Pharma Inventory', 'Real-time inventory tracking system for pharma', 'ERP', 4),
(5, 'Renewable Energy Tracker', 'System to track renewable energy utilization', 'IoT', 5),
(6, 'Traffic Prediction', 'AI system to predict traffic congestion', 'AI', 6),
(7, 'Food Delivery System', 'Mobile app for real-time food delivery', 'Mobile Development', 7),
(8, 'Healthcare Chatbot', 'AI-based chatbot for health consultation', 'AI', 8),
(9, 'Retail ERP', 'Enterprise Resource Planning for Retail', 'ERP', 9),
(10, 'Blockchain Voting', 'Secure blockchain-based voting system', 'Blockchain', 10),
(11, 'Pharma Inventory', 'Real-time inventory tracking system for pharma', 'ERP', 2),
(12, 'Renewable Energy Tracker', 'System to track renewable energy utilization', 'IoT', 3);

INSERT INTO industry_guide (eid, fname, lname, email, cid)
VALUES
(201, 'Keyur', 'Adhyaru', 'keyur.adhyaru@rkit.edu.in', 1),
(202, 'Sneha', 'Patel', 'sneha.patel@techm.com', 2),
(203, 'Vikas', 'Sharma', 'vikas.sharma@infosys.com', 3),
(204, 'Geeta', 'Desai', 'geeta.desai@wipro.com', 4),
(205, 'Rohan', 'Kapoor', 'rohan.kapoor@tcs.com', 5),
(206, 'Aarti', 'Bhatt', 'aarti.bhatt@lntinfotech.com', 6),
(207, 'Manish', 'Joshi', 'manish.joshi@cygnet.com', 7),
(208, 'Piyush', 'Thakar', 'piyush.thakar@persistent.com', 8),
(209, 'Deepak', 'Parmar', 'deepak.parmar@mindtree.com', 9),
(210, 'Kiran', 'Trivedi', 'kiran.trivedi@capgemini.com', 10);

INSERT INTO industry_guide_mob (eid, mobile)
VALUES 
(201, '9123456780'),
(202, '9123456781'),
(203, '9123456782'),
(204, '9123456782'),
(205, '9123456782'),
(206, '9123456782'),
(207, '9123456782'),
(208, '9123456782'),
(209, '9123456782'),
(210, '9123456782');

INSERT INTO professor (eid, fname, lname, email)
VALUES
(101, 'Mayur', 'Vegad', 'mayur.vegad@college.com'),
(102, 'Meena', 'Shah', 'meena.shah@college.com'),
(103, 'Vishal', 'Dave', 'vishal.dave@college.com'),
(104, 'Amruta', 'Joshi', 'amruta.joshi@college.com'),
(105, 'Harish', 'Trivedi', 'harish.trivedi@college.com'),
(106, 'Seema', 'Mehta', 'seema.mehta@college.com');

INSERT INTO professor_mob (eid, mobile)
VALUES 
(101, '9123456780'),
(102, '9123456781'),
(103, '9123456782'),
(104, '9123456782'),
(105, '9123456782'),
(106, '9123456782');

INSERT INTO student (sid, fname, lname, email, college_guide_eid, industry_guide_eid, cid, pid, branch_name)
VALUES
(1, 'Navneet', 'Thakor', 'navneet.thakor@student.com', 101, 201, 1, 1, 'Rajkot'),
(2, 'Meet', 'Joshi', 'meet.joshi@student.com', 101, 201, 1, 2, 'Ahmedabad'),
(3, 'Rohanshu', 'Banodha', 'rohanshu.banodha@student.com', 101, 201, 1, 3, 'Rajkot'),
(4, 'Karan', 'Patel', 'karan.patel@student.com', 102, 204, 4, 4, 'Ahmedabad'),
(5, 'Pooja', 'Sharma', 'pooja.sharma@student.com', 102, 205, 5, 5, 'Gandhinagar'),
(6, 'Ankit', 'Raval', 'ankit.raval@student.com', 106, 206, 6, 6, 'Ahmedabad'),
(7, 'Riya', 'Mehta', 'riya.mehta@student.com', 103, 207, 7, 7, 'Ahmedabad'),
(8, 'Sahil', 'Desai', 'sahil.desai@student.com', 103, 208, 8, 8, 'Ahmedabad'),
(9, 'Priya', 'Kapoor', 'priya.kapoor@student.com', 104, 209, 9, 9, 'Ahmedabad'),
(10, 'Dhruv', 'Shah', 'dhruv.shah@student.com', 105, 210, 10, 10, 'Gandhinagar'),
(11, 'Priya', 'Kapoor', 'priya.kapoor@student.com', 106, 202, 2, 11, 'Ahmedabad'),
(12, 'Dhruv', 'Shah', 'dhruv.shah@student.com', 104, 203, 3, 12, 'Ahmedabad');


INSERT INTO student_mob (sid, mobile)
VALUES 
(1, '9123456780'),
(2, '9123456781'),
(3, '9123456782'),
(4, '9123456782'),
(5, '9123456782'),
(6, '9123456782'),
(7, '9123456782'),
(8, '9123456782'),
(9, '9123456782'),
(10, '9123456782'),
(11, '9123456782'),
(12, '9123456782');

INSERT INTO panel_professors (sid, eid)
VALUES 
(1, 101),
(1, 102),
(1, 103),
(2, 101),
(2, 102),
(2, 103),
(3, 101),
(3, 102),
(3, 103),
(4, 104),
(4, 105),
(5, 104),
(5, 105),
(5, 106),
(6, 101),
(6, 102),
(7, 101),
(7, 102),
(7, 103),
(8, 101),
(8, 102),
(8, 103),
(9, 101),
(9, 102),
(9, 103),
(10, 104),
(10, 105),
(11, 104),
(11, 105),
(11, 106),
(12, 101),
(12, 102);

INSERT INTO assesment (sid, mid1_marks, mid1_suggestions, mid1_status, mid2_marks, mid2_suggestions, mid2_status, external_marks, external_status)
VALUES
(1, 85, 'Good effort, keep it up', 1, 90, 'Excellent progress', 1, 95, 1),
(2, 70, 'Needs improvement in coding', 1, 75, 'Improved coding skills', 1, 80, 1),
(3, 60, 'Weak in documentation', 1, 65, 'Better documentation', 1, 70, 1),
(4, 50, 'Weak presentation skills', 0, 0, "", 0, 0, 0),
(5, 95, 'Outstanding', 1, 95, 'Maintained excellence', 1, 98, 1),
(6, 45, 'Needs focus on core concepts', 1, 50, 'Better understanding of concepts', 1, 60, 1),
(7, 88, 'Well-prepared', 1, 85, 'Sustained good performance', 1, 90, 1),
(8, 72, 'Good effort, slight improvement needed', 1, 78, 'Steady improvement', 1, 85, 1),
(9, 66, 'Average performance', 1, 70, 'Slight improvement', 1, 75, 1),
(10, 94, 'Excellent progress', 1, 96, 'Outstanding', 1, 99, 1),
(11, 88, 'Well-prepared', 1, 85, 'Sustained good performance', 1, 90, 1),
(12, 72, 'Good effort, slight improvement needed', 1, 78, 'Steady improvement', 1, 85, 1);

