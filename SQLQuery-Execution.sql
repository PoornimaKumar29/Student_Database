use SISDB

select * from Students
select * from Teachers
select * from Courses
select * from Enrollmeant
select * from Payments
--1.Write an SQL query to insert a new student into the "Students" table with the following details:
--a. First Name: John
--© Hexaware Technologies Limited. All rights www.hexaware.com
--b. Last Name: Doe
--c. Date of Birth: 1995-08-15
--d. Email: john.doe@example.com
--e. Phone Number: 1234567890
insert into Students (Student_Id,Student_Firstname,Student_Lastname,Student_DOB,Student_Email,Student_Phone)
values
(11,'John','Doe','1995-08-15','john.doe@example.com',1234567890)

--2 o enroll a student in a course. Choose an existing student and course and
--insert a record into the "Enrollments" table with the enrollment date
UPDATE Teachers  
SET Teacher_Email = 'new.email@example.com'  
WHERE Teacher_Id = 4;
--3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and
--modify their email address.
UPDATE Courses  
SET Teacher_Id = 6  
WHERE Course_Id = 4;

--4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select
--an enrollment record based on the student and course.
delete from Enrollmeant where Student_id=10 

--5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and
--teacher from the respective tables.

update Courses set Teacher_Id=3
where Course_Id=4
--6. Delete a specific student from the "Students" table and remove all their enrollment records
--from the "Enrollments" table. Be sure to maintain referential integrity.

delete from Students where Student_Firstname='Raj'

--7. Update the payment amount for a specific payment record in the "Payments" table. Choose any
--payment record and modify the payment amount.

UPDATE Payments  
SET Amount = 5500  
WHERE Payment_Id = 2;
-----------------------------------------------------------------Task 2---------------------------------------------
--1.Total Payments Made by a Specific Student

SELECT S.Student_Firstname, S.Student_Lastname, 
SUM(P.Amount) AS Total_Payment
FROM Students S
JOIN Payments P ON S.Student_Id = P.Student_Id
WHERE S.Student_Id = 10
GROUP BY S.Student_Firstname, S.Student_Lastname

--2.Courses with the Count of Students Enrolled

SELECT C.Course_Name, COUNT(E.Student_Id) AS Student_Count
FROM Courses C
LEFT JOIN Enrollmeant E ON C.Course_Id = E.Course_Id
GROUP BY C.Course_Name
--3. Students Who Have Not Enrolled in Any Course

select s.student_firstname, s.student_lastname
from students s
left join enrollmeant e on s.student_id = e.student_id
where e.student_id is null

--4.Students and the courses they are enrolled in
select s.student_firstname, s.student_lastname, c.course_name
from students s
join enrollmeant e on s.student_id = e.student_id
join courses c on e.course_id = c.course_id
--5.Teachers and their assigned courses
select t.teacher_firstname, t.teacher_lastname, c.course_name
from teachers t
join courses c on t.teacher_id = c.teacher_id
--6.List of students and their enrollment dates for a specific course
select s.student_firstname, s.student_lastname, e.enrollment_date
from students s
join enrollmeant e on s.student_id = e.student_id
join courses c on e.course_id = c.course_id
where c.course_id = 1 

--7.Students who have not made any payments
select s.student_firstname, s.student_lastname
from students s
left join payments p on s.student_id = p.student_id
where p.student_id is null

--8.Courses that have no enrollments
select c.course_name
from courses c
left join enrollmeant e on c.course_id = e.course_id
where e.course_id is null
--9.students enrolled in more than one course
select s.student_firstname, s.student_lastname, 
count(e.course_id) as course_count
from students s
join enrollmeant e on s.student_id = e.student_id
group by s.student_firstname, s.student_lastname
having count(e.course_id) > 0
--10.Teachers who are not assigned to any courses
select t.teacher_firstname, t.teacher_lastname
from teachers t
left join courses c on t.teacher_id = c.teacher_id
where c.teacher_id is null

-----------------------------------------------------------------TASK 4-----------------------------------------------

--1.Average number of students enrolled in each course
select avg(student_count) as avg_students_per_course
from (select course_id, count(student_id) as student_count
from enrollmeant group by course_id) 
as course_enrollmeant
--2.Student(s) who made the highest payment
select s.student_firstname, s.student_lastname, p.amount
from students s
join payments p on s.student_id = p.student_id
where p.amount = (select max(amount) from payments)
--3.Courses with the highest number of enrollments

select c.course_name, count(e.student_id) as enrollment_count
from courses c
join enrollmeant e on c.course_id = e.course_id
group by c.course_id, c.course_name
having count(e.student_id) = (select max(enrollment_count) 
from (select count(student_id) as enrollment_count
from enrollmeant group by course_id)
as enrollments_per_course)

--4.Total payments made to courses taught by each teacher
select t.teacher_firstname, t.teacher_lastname, 
(select sum(p.amount) from payments p
join enrollmeant e on p.student_id = e.student_id
join courses c on e.course_id = c.course_id
where c.teacher_id = t.teacher_id) as total_payment
from teachers t

--5.Students enrolled in all available courses
select s.student_firstname, s.student_lastname
from students s where
(select count(course_id) from enrollmeant 
where student_id = s.student_id) = 
(select count(course_id) from courses)

--6.Teachers who have not been assigned to any courses
select teacher_firstname, teacher_lastname
from teachers
where teacher_id not in 
(select distinct teacher_id from courses)

--7.Average age of all students
select avg(datediff(year, student_dob, getdate()))
as avg_age  
from students

--8.Identify courses with no enrollments

select course_name  
from courses  
where course_id not in (select course_id from 
enrollmeant)
--9.Total payments made by each student for each course

select student_id, course_id,  
(select sum(amount) from payments p 
where p.student_id = e.student_id) as total_payment  
from enrollmeant e

--10. Identify students who made more than one payment

select student_id  
from payments  
group by student_id  
having count(payment_id) > 0
--11.Total payments made by each student

select s.student_id, s.student_firstname, sum(p.amount) as total_payment  
from students s  
join payments p on s.student_id = p.student_id  
group by s.student_id, s.student_firstname
--12.List of courses with student count

select c.course_name, count(e.student_id) as student_count  
from courses c  
left join enrollmeant e on c.course_id = e.course_id  
group by c.course_name

--13.Average payment amount by students

select s.student_id, avg(p.amount) as avg_payment  
from students s  
join payments p on s.student_id = p.student_id  
group by s.student_id;




















