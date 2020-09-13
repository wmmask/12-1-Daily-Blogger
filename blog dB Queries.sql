
USE blog;
GO
BEGIN TRAN
INSERT INTO BlogPost
values	('Test Data2', 'This is Test Data2!', '2020-09-02 00:00:00.000')
COMMIT TRAN;

SELECT *
FROM BlogPost;