use sisdb
---------------------------------------create StudentTable-----------------------------------
create table Students(
Student_Id int,
constraint pk_studentid primary key(Student_Id),
Student_Firstname varchar(100) not null,
Student_Lastname varchar(100) not null,
Student_DOB date not null,
Student_Email varchar(100) unique not null,
Student_Phone bigint unique not null
)
----------------------------------------------create TeachersTable--------------------------
create table Teachers(
Teacher_Id int,
constraint pk_teacherid primary key(Teacher_Id),
Teacher_Firstname varchar(100) not null,
Teacher_Lastname varchar(100) not null,
Teacher_Email varchar(100) unique not null
)
-------------------------------------------create CourseTable----------------------------------------
create table Courses(
Course_Id int,
constraint pk_courseid primary key(Course_Id),
Course_Name varchar(100) not null,
Credits int not null,
Teacher_Id int
constraint fk_teacherid foreign key(Teacher_Id)  references Teachers(Teacher_Id) on delete cascade
)
--------------------------------------Create Enrollmenttable------------------------------------------------------
create table Enrollmeant(
Enrollment_Id int 
constraint pk_enrollmentid primary key(Enrollment_Id),
Student_Id int 
constraint fk_studnetid foreign key(Student_Id) references Students(Student_id) on delete cascade,
Course_Id int 
constraint fk_courseid foreign key(Course_Id) references Courses(Course_Id) on delete cascade,
Enrollment_Date date not null
)

-------------------------------------------create Paymentatble---------------------------------------------------------------
create table Payments(
Payment_Id int 
constraint pk_payment primary key(Payment_Id),
Student_Id int 
constraint fk_studentid foreign key(Student_id) references Students(Student_Id) on delete cascade,
Amount int not null,
Payment_Date date not null
)
