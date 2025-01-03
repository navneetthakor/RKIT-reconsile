-- DCL : data control language
-- used to control access to the data in database

# 1) Check users

SELECT * FROM mysql.user;

# 2) Create new user

CREATE USER 'nk'@'localhost' IDENTIFIED BY 'nk@1234';
CREATE USER 'nk2'@'localhost' IDENTIFIED BY 'nk2@1234';
CREATE USER 'nk3'@'localhost' IDENTIFIED BY 'nk3@1234';

# 3) Grant
--	Grant option : to provide ability to grant privileges to other users
-- it is cascade : if x have granted privilages to -> y 
-- and then if someone revokes privillages from x,
--  then automaticaly it would be removed from y

GRANT ALL PRIVILEGES
ON fsep_model.*
TO 'nk'@'localhost' with grant option;

GRANT SELECT, INSERT
ON fsep_model.*
TO 'nk2'@'localhost';

GRANT SELECT, INSERT
ON fsep_model.student
TO 'nk3'@'localhost';

# 4) Revoke

REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'nk'@'localhost';

REVOKE SELECT, INSERT
ON fsep_model.*
FROM 'nk2'@'localhost';

SHOW GRANTS FOR 'nk'@'localhost';