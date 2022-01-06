-- CRUD

-- SELECT
select * from tblStudent;
select * from tblStudent where not (Salary<300);

-- CREATE
insert into tblStudent(Name, Surname, DateOfBirth, Salary) 
values ('Samir3', 'Ehmedov3', '1996-09-15', 300)

-- UPDATE
update tblStudent set Salary=Salary+200  where Id=2

-- DELETE
select * from tblStudent where Id=2

--GROUP by DATE and filter
select DATEPART(YEAR, DateOfBirth) as Year, COUNT(*) as StudentCount from tblStudent
group by DATEPART(YEAR, DateOfBirth)
having COUNT(*) > 2

-- JOIN
select s.Name, s.Surname, c.Name CourseName, sc.StartDate from tblStudentCourse sc
join tblStudent s on sc.StudentId = s.Id
join tblCourse c on sc.CourseId = c.Id