using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using StudentInformationSystem.entity;

namespace StudentInformationSystem
{
    public class StudentInformationSystemImpl : IStudentInformationSystem
    {
        private string connectionString = "Data Source=POORNIMA\\SQLSERVER2022;Initial Catalog=SISDB;Integrated Security=True;";

        // Enroll student in course using IDs
        public void EnrollInCourse(int studentId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Enrollmeant (Student_Id, Course_Id, Enrollment_Date) VALUES (@StudentId, @CourseId, @EnrollmentDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine($"Student {studentId} enrolled in Course {courseId}.");
            }
        }

        // Update student info using individual fields
        public void UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dob, string email, long phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET Student_Firstname = @FirstName, Student_Lastname = @LastName, Student_DOB = @DOB, Student_Email = @Email, Student_Phone = @Phone WHERE Student_Id = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine($"Updated info for student ID {studentId}.");
            }
        }

        // Make a payment using individual values
        public void MakePayment(int studentId, decimal amount, DateTime paymentDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Payments (Student_Id, Amount, Payment_Date) VALUES (@StudentId, @Amount, @PaymentDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@PaymentDate", paymentDate);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine($"Payment of {amount} recorded for student ID {studentId}.");
            }
        }

        // Display student info
        public void DisplayStudentInfo(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Student_Firstname, Student_Lastname, Student_DOB, Student_Email, Student_Phone FROM Students WHERE Student_Id = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Student Info:\nName: {reader["Student_Firstname"]} {reader["Student_Lastname"]}\nDOB: {reader["Student_DOB"]}\nEmail: {reader["Student_Email"]}\nPhone: {reader["Student_Phone"]}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

                connection.Close();
            }
        }

        // Get enrolled courses for a student by ID
        public List<Course> GetEnrolledCourses(int studentId)
        {
            List<Course> enrolledCourses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT c.Course_Id, c.Course_Name, c.Teacher_Id FROM Enrollmeant" +
                    "INNER JOIN Courses c ON e.Course_Id = c.Course_Id WHERE e.Student_Id = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course
                    {
                        Course_Id = Convert.ToInt32(reader["Course_Id"]),
                        Course_Name = reader["Course_Name"].ToString(),
                        Teacher_Id = Convert.ToInt32(reader["Teacher_Id"])
                    };
                    enrolledCourses.Add(course);
                }

                connection.Close();
            }

            return enrolledCourses;
        }

        // Get payment history for a student by ID
        public List<Payment> GetPaymentHistory(int studentId)
        {
            List<Payment> paymentHistory = new List<Payment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Payment_Id, Amount, Payment_Date FROM Payments WHERE Student_Id = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Payment payment = new Payment
                    {
                        Payment_Id = Convert.ToInt32(reader["Payment_Id"]),
                        Student_Id = studentId,
                        Amount = Convert.ToInt32(reader["Amount"]),
                        Payment_Date = Convert.ToDateTime(reader["Payment_Date"])
                    };
                    paymentHistory.Add(payment);
                }

                connection.Close();
            }

            return paymentHistory;
        }
        public void AssignTeacherToCourse(int teacherId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Courses SET Teacher_Id = @TeacherId WHERE Course_Id = @CourseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine($"Teacher with ID {teacherId} assigned to course {courseId}.");
            }
        }
        public void UpdateCourseInfo(int courseId, string courseCode, string courseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Courses SET Course_Name = @CourseName WHERE Course_Id = @CourseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseName", courseName);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine($"Course ID {courseId} updated.");
            }
        }

        public void DisplayCourseInfo(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses WHERE Course_Id = @CourseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"Course ID: {reader["Course_Id"]}");
                    Console.WriteLine($"Course Name: {reader["Course_Name"]}");
                    Console.WriteLine($"Credits: {reader["Credits"]}");
                    Console.WriteLine($"Teacher ID: {reader["Teacher_Id"]}");
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }

                reader.Close();
                connection.Close();
            }
        }
        public List<Enrollment> GetEnrollments(int courseId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Enrollmeant WHERE Course_Id = @CourseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment
                    {
                        Enrollment_Id = (int)reader["New_Enrollment_Id"],
                        Student_Id = (int)reader["Student_Id"],
                        Course_Id = (int)reader["Course_Id"],
                        Enrollment_Date = Convert.ToDateTime(reader["Enrollment_Date"])
                    };
                    enrollments.Add(enrollment);
                }

                reader.Close();
                connection.Close();
            }

            return enrollments;
        }
        public Teacher GetAssignedTeacher(int courseId)
        {
            Teacher teacher = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT T.Teacher_Id, T.Teacher_Firstname, T.Teacher_Lastname
        FROM Teachers T
        INNER JOIN Courses C ON T.Teacher_Id = C.Teacher_Id
        WHERE C.Course_Id = @CourseId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    teacher = new Teacher
                    {
                        Teacher_Id = (int)reader["Teacher_Id"],
                        Teacher_Firstname = reader["Teacher_Firstname"].ToString(),
                        Teacher_Lastname = reader["Teacher_Lastname"].ToString()
                    };
                }

                reader.Close();
                connection.Close();
            }

            return teacher;
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            Enrollment enrollment = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Enrollmeant WHERE New_Enrollment_Id = @New_EnrollmentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@New_EnrollmentId", enrollmentId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    enrollment = new Enrollment
                    {
                        Enrollment_Id = Convert.ToInt32(reader["New_Enrollment_Id"]),
                        Student_Id = Convert.ToInt32(reader["Student_Id"]),
                        Course_Id = Convert.ToInt32(reader["Course_Id"]),
                        Enrollment_Date = Convert.ToDateTime(reader["Enrollment_Date"])
                    };
                }
            }

            return enrollment;
        }

        public Student GetEnrollmentStudent(Enrollment enrollment)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT s.Student_Id, s.Student_Firstname, s.Student_Lastname, s.Student_DOB, s.Student_Email, s.Student_Phone
            FROM Enrollmeant e
            JOIN Students s ON e.Student_Id = s.Student_Id
            WHERE e.New_Enrollment_Id = @New_EnrollmentId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@New_EnrollmentId", enrollment.Enrollment_Id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Student_Id = Convert.ToInt32(reader["Student_Id"]),
                        Student_Firstname = reader["Student_Firstname"].ToString(),
                        Student_Lastname = reader["Student_Lastname"].ToString(),
                        Student_DOB = Convert.ToDateTime(reader["Student_DOB"]),
                        Student_Email = reader["Student_Email"].ToString(),
                        Student_Phone = Convert.ToInt64(reader["Student_Phone"])
                    };
                }
            }
            return student;
        }
        public Course GetEnrollmentCourse(Enrollment enrollment)
        {
            Course course = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT c.Course_Id, c.Course_Name, c.Credits, c.Teacher_Id
            FROM Enrollmeant e
            JOIN Courses c ON e.Course_Id = c.Course_Id
            WHERE e.New_Enrollment_Id = @New_Enrollment_Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@New_Enrollment_Id", enrollment.Enrollment_Id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    course = new Course
                    {
                        Course_Id = Convert.ToInt32(reader["Course_Id"]),
                        Course_Name = reader["Course_Name"].ToString(),
                        Credits = Convert.ToInt32(reader["Credits"]),
                        Teacher_Id = Convert.ToInt32(reader["Teacher_Id"])
                    };
                }
            }
            return course;
        }
        public void UpdateTeacherInfo(int teacherId, string columnName, object value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"UPDATE Teachers SET {columnName} = @Value WHERE Teacher_Id = @TeacherId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Value", value);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.ExecuteNonQuery();

                Console.WriteLine($"Teachers Column updated.");

            }
        }

        public void DisplayTeacherInfo(int teacherId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Teachers WHERE Teacher_Id = @TeacherId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Teacher_Id"]}, Name: {reader["Teacher_Firstname"]} {reader["Teacher_Lastname"]}, Email: {reader["Teacher_Email"]}");
                }
                else
                {
                    Console.WriteLine("Teacher not found.");
                }
            }
        }

        public List<Course> GetAssignedCourses(int teacherId)
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Courses WHERE Teacher_Id = @TeacherId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course
                    {
                        Course_Id = Convert.ToInt32(reader["Course_Id"]),
                        Course_Name = reader["Course_Name"].ToString(),
                        Credits = Convert.ToInt32(reader["Credits"]),
                        Teacher_Id = Convert.ToInt32(reader["Teacher_Id"])
                    };
                    courses.Add(course);
                }
            }

            return courses;
        }
        public Student GetPaymentStudent(int paymentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT s.Student_Id, s.Student_Firstname, s.Student_Lastname, s.Student_Email, s.Student_Phone " +
                               "FROM Payments p " +
                               "JOIN Students s ON p.Student_Id = s.Student_Id " +
                               "WHERE p.Payment_Id = @PaymentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentId", paymentId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Student
                    {
                        Student_Id = Convert.ToInt32(reader["Student_Id"]),
                        Student_Firstname = reader["Student_Firstname"].ToString(),
                        Student_Lastname = reader["Student_Lastname"].ToString(),
                        Student_Email = reader["Student_Email"].ToString(),
                        Student_Phone = Convert.ToInt64(reader["Student_Phone"])
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        // Method to get the payment amount based on Payment ID
        public int GetPaymentAmount(int paymentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Amount FROM Payments WHERE Payment_Id = @PaymentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentId", paymentId);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Method to get the payment date based on Payment ID
        public DateTime GetPaymentDate(int paymentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Payment_Date FROM Payments WHERE Payment_Id = @PaymentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentId", paymentId);

                return Convert.ToDateTime(command.ExecuteScalar());
            }
        }


    }

}
