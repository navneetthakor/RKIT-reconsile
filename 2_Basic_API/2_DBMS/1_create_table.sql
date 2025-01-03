use fsep_model;
CREATE TABLE company (
    cid INT PRIMARY KEY,                -- Company ID
    name VARCHAR(200)                   -- Company Name
);

CREATE TABLE company_branch_info (
    cid INT,                            -- Company ID (Foreign Key to company)
    branch_name VARCHAR(100),           -- Branch Name
    address VARCHAR(255),               -- Branch Address
    mobile VARCHAR(15),                 -- Branch Mobile
    email VARCHAR(100),                 -- Branch Email
    PRIMARY KEY (cid, branch_name),
    FOREIGN KEY (cid) REFERENCES company(cid)
);

CREATE TABLE project_info (
    pid INT PRIMARY KEY,                -- Project ID
    title VARCHAR(200),                 -- Project Title
    info TEXT,                           -- Project Info
    type VARCHAR(100),                  -- Project Type
    cid INT,                            -- Company ID (Foreign Key to company)
    FOREIGN KEY (cid) REFERENCES company(cid)
);

CREATE TABLE industry_guide (
    eid INT PRIMARY KEY,                -- Industry Guide ID
    fname VARCHAR(100),                 -- First Name
    lname VARCHAR(100),					-- Last Name
    email VARCHAR(100),                 -- Email
    cid INT,                            -- Company ID (Foreign Key to company)
    FOREIGN KEY (cid) REFERENCES company(cid)
);

CREATE TABLE industry_guide_mob(
    eid INT,                            -- Industry Guide ID (Foreign Key to industry_guide)
    mobile VARCHAR(10),                 -- Mobile Number
    PRIMARY KEY (eid, mobile),
    FOREIGN KEY (eid) REFERENCES industry_guide(eid)
);


CREATE TABLE professor (
    eid INT PRIMARY KEY,                -- Professor ID
    fname VARCHAR(100),                 -- First Name
    lname VARCHAR(100),                 -- Last Name
    email VARCHAR(100)                  -- Email
);

CREATE TABLE professor_mob (
    eid INT,                            -- Professor ID (Foreign Key to professor)
    mobile VARCHAR(10),                 -- Mobile Number
    PRIMARY KEY (eid, mobile),
    FOREIGN KEY (eid) REFERENCES professor(eid)
);


CREATE TABLE student (
    sid INT PRIMARY KEY,                -- Student ID
    fname VARCHAR(100),                 -- First Name
    lname VARCHAR(100),                 -- Last Name
    email VARCHAR(100),                 -- Email
    college_guide_eid INT,              -- College Guide (Foreign Key to professor)
    industry_guide_eid INT,             -- Industry Guide (Foreign Key to indusgtry guide)
    cid INT,                            -- Company ID (Foreign Key to company_branch_info)
    pid INT,                            -- Project ID (Foreign Key to project_info)
    branch_name VARCHAR(100),			-- Branch name (Foreign Key to company_branch_info)
    FOREIGN KEY (college_guide_eid) REFERENCES professor(eid),
    FOREIGN KEY (industry_guide_eid) REFERENCES industry_guide(eid),
    FOREIGN KEY (pid) REFERENCES project_info(pid),
    FOREIGN KEY (cid, branch_name) REFERENCES company_branch_info(cid, branch_name)
);

CREATE TABLE student_mob (
    sid INT,                            -- Student ID (Foreign Key to student)
    mobile VARCHAR(10),                 -- Mobile Number
    PRIMARY KEY (sid, mobile),
    FOREIGN KEY (sid) REFERENCES student(sid)
);

CREATE TABLE panel_professors (
    sid INT,                            -- Student ID (Foreign Key to student)
    eid INT,                            -- Professor ID (Foreign Key to professor)
    PRIMARY KEY (sid, eid),
    FOREIGN KEY (sid) REFERENCES student(sid),
    FOREIGN KEY (eid) REFERENCES professor(eid)
);

CREATE TABLE assesment (
    sid INT,                            -- Student ID (Foreign Key to student)
    mid1_marks INT,                     -- Mid 1 Marks
    mid1_suggestions TEXT,              -- Mid 1 Suggestions
    mid1_status BOOLEAN,            -- Mid 1 Status
    mid2_marks INT,                     -- Mid 2 Marks
    mid2_suggestions TEXT,              -- Mid 2 Suggestions
    mid2_status BOOLEAN,            -- Mid 2 Status
    external_marks INT,                 -- External Marks
    external_status BOOLEAN,        -- External Status
    PRIMARY KEY (sid),
    FOREIGN KEY (sid) REFERENCES student(sid)
);
