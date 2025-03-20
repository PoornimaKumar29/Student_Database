
------------------------------------------------------inserting in student table------------------------------------------
INSERT INTO Students (Student_Id, Student_Firstname, Student_Lastname, Student_DOB, Student_Email, Student_Phone) VALUES
(1, 'Amit', 'Sharma', '2000-05-12', 'amit.sharma@example.com', 9876543210),
(2, 'Priya', 'Verma', '1999-08-25', 'priya.verma@example.com', 8765432109),
(3, 'Raj', 'Patel', '2001-02-18', 'raj.patel@example.com', 7654321098),
(4, 'Sneha', 'Rao', '2000-11-30', 'sneha.rao@example.com', 6543210987),
(5, 'Vikram', 'Singh', '1998-07-10', 'vikram.singh@example.com', 5432109876),
(6, 'Anjali', 'Nair', '2002-03-22', 'anjali.nair@example.com', 4321098765),
(7, 'Rohan', 'Das', '2001-06-15', 'rohan.das@example.com', 3210987654),
(8, 'Kavya', 'Iyer', '1999-12-05', 'kavya.iyer@example.com', 2109876543),
(9, 'Arjun', 'Mishra', '2000-09-20', 'arjun.mishra@example.com', 1098765432),
(10, 'Meera', 'Reddy', '2001-04-08', 'meera.reddy@example.com', 9876543201);


--------------------------------------------insert data in teacher table-----------------------------------------------
INSERT INTO Teachers (Teacher_Id, Teacher_Firstname, Teacher_Lastname, Teacher_Email) VALUES
(1, 'Rahul', 'Sharma', 'rahul.sharma@example.com'),
(2, 'Neha', 'Verma', 'neha.verma@example.com'),
(3, 'Amit', 'Patel', 'amit.patel@example.com'),
(4, 'Sneha', 'Rao', 'sneha.rao@example.com'),
(5, 'Vikram', 'Singh', 'vikram.singh@example.com'),
(6, 'Anjali', 'Nair', 'anjali.nair@example.com'),
(7, 'Rohan', 'Das', 'rohan.das@example.com'),
(8, 'Kavya', 'Iyer', 'kavya.iyer@example.com'),
(9, 'Arjun', 'Mishra', 'arjun.mishra@example.com'),
(10, 'Meera', 'Reddy', 'meera.reddy@example.com');


------------------------------------------------insert in course table-------------------------------------------------------------
INSERT INTO Courses (Course_Id, Course_Name, Credits, Teacher_Id) VALUES
(1, 'Mathematics', 4, 1),
(2, 'Physics', 3, 2),
(3, 'Chemistry', 4, 3),
(4, 'Biology', 3, 4),
(5, 'Computer Science', 5, 5),
(6, 'English', 2, 6),
(7, 'History', 3, 7),
(8, 'Economics', 4, 8),
(9, 'Psychology', 3, 9),
(10, 'Philosophy', 2, 10);



------------------------------------------------insert in Enrollment table-------------------------------------------------------------

INSERT INTO Enrollmeant(Enrollment_Id, Student_Id, Course_Id, Enrollment_Date) VALUES
(1, 1, 1, '2024-01-15'),
(2, 2, 2, '2024-02-10'),
(3, 3, 3, '2024-03-05'),
(4, 4, 4, '2024-04-01'),
(5, 5, 5, '2024-05-12'),
(6, 6, 6, '2024-06-18'),
(7, 7, 7, '2024-07-22'),
(8, 8, 8, '2024-08-09'),
(9, 9, 9, '2024-09-14'),
(10, 10, 10, '2024-10-20');

------------------------------------------------insert in payment table-------------------------------------------------------------
INSERT INTO Payments (Payment_Id, Student_Id, Amount, Payment_Date) VALUES
(1, 1, 5000, '2024-01-20'),
(2, 2, 4500, '2024-02-15'),
(3, 3, 4800, '2024-03-10'),
(4, 4, 5200, '2024-04-05'),
(5, 5, 5100, '2024-05-18'),
(6, 6, 5300, '2024-06-22'),
(7, 7, 4700, '2024-07-25'),
(8, 8, 4900, '2024-08-12'),
(9, 9, 5000, '2024-09-19'),
(10, 10, 4600, '2024-10-25');








