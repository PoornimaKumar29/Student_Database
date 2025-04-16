using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using StudentInformationSystem.entity;

namespace StudentInformationSystem
{
    class MainModule
    {
        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    Console.WriteLine("Database connection successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
            }

            IStudentInformationSystem studentSystem = new StudentInformationSystemImpl();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Student Information System");
                Console.WriteLine("1. Enroll in Course");
                Console.WriteLine("2. Update Student Info");
                Console.WriteLine("3. Make Payment");
                Console.WriteLine("4. Display Student Info");
                Console.WriteLine("5. Get Enrolled Courses");
                Console.WriteLine("6. View Payment History");
                Console.WriteLine("7. Assign Teacher to Course");
                Console.WriteLine("8. Update Course Info");
                Console.WriteLine("9. Display Course Info");
                Console.WriteLine("10. Get Course Enrollments");
                Console.WriteLine("11. Get Assigned Teacher");
                Console.WriteLine("12. Get Student Information from Enrollment");
                Console.WriteLine("13. Get Course Information from Enrollment");
                Console.WriteLine("14.Update Teacher Info");
                Console.WriteLine("15. Display Teacher Info");
                Console.WriteLine("16. Get Assigned Courses");
                Console.WriteLine("17. Get Student Info from Payment");
                Console.WriteLine("18. Get Payment Amount");
                Console.WriteLine("19. Get Payment Date");
                Console.WriteLine("20. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Student ID: ");
                        int studentId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Course ID: ");
                        int courseId = int.Parse(Console.ReadLine());
                        studentSystem.EnrollInCourse(studentId, courseId);
                        break;

                    case "2":
                        Console.WriteLine("Enter Student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new First Name: ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter new Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter new Date of Birth (yyyy-mm-dd): ");
                        DateTime dob = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new Email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter new Phone number: ");
                        long phone = long.Parse(Console.ReadLine());

                        studentSystem.UpdateStudentInfo(studentId, firstName, lastName, dob, email, phone);
                        break;

                    case "3":
                        Console.WriteLine("Enter Student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Payment Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Payment Date (yyyy-mm-dd): ");
                        DateTime paymentDate = DateTime.Parse(Console.ReadLine());

                        studentSystem.MakePayment(studentId, amount, paymentDate);
                        break;

                    case "4":
                        Console.WriteLine("Enter Student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        studentSystem.DisplayStudentInfo(studentId);
                        break;

                    case "5":
                        Console.WriteLine("Enter Student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        List<Course> enrolledCourses = studentSystem.GetEnrolledCourses(studentId);
                        Console.WriteLine("Enrolled Courses:");
                        foreach (var c in enrolledCourses)
                        {
                            Console.WriteLine($"{c.Course_Name} (Course ID: {c.Course_Id})");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Enter Student ID: ");
                        studentId = int.Parse(Console.ReadLine());
                        List<Payment> paymentHistory = studentSystem.GetPaymentHistory(studentId);
                        Console.WriteLine("Payment History:");
                        foreach (var payment in paymentHistory)
                        {
                            Console.WriteLine($"Payment ID: {payment.Payment_Id}, Amount: {payment.Amount}, Date: {payment.Payment_Date}");
                        }
                        break;
                    case "7":
                        Console.Write("Enter Teacher ID: ");
                        int teacherId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        courseId = int.Parse(Console.ReadLine());
                        studentSystem.AssignTeacherToCourse(teacherId, courseId);
                        break;

                    case "8":
                        Console.Write("Enter Course ID: ");
                        courseId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course Code (optional/unused): ");
                        string courseCode = Console.ReadLine(); // not stored in DB but required by method
                        Console.Write("Enter Course Name: ");
                        string courseName = Console.ReadLine();
                        studentSystem.UpdateCourseInfo(courseId, courseCode, courseName);
                        break;

                    case "9":
                        Console.Write("Enter Course ID: ");
                        courseId = int.Parse(Console.ReadLine());
                        studentSystem.DisplayCourseInfo(courseId);
                        break;

                    case "10":
                        Console.Write("Enter Course ID: ");
                        courseId = int.Parse(Console.ReadLine());
                        List<Enrollment> enrollments = studentSystem.GetEnrollments(courseId);
                        Console.WriteLine("Enrollments for Course:");
                        foreach (var e in enrollments)
                        {
                            Console.WriteLine($"Enrollment ID: {e.Enrollment_Id}, Student ID: {e.Student_Id}, Date: {e.Enrollment_Date}");
                        }
                        break;

                    case "11":
                        Console.Write("Enter Course ID: ");
                        courseId = int.Parse(Console.ReadLine());
                        Teacher assignedTeacher = studentSystem.GetAssignedTeacher(courseId);
                        if (assignedTeacher != null)
                        {
                            Console.WriteLine($"Assigned Teacher: {assignedTeacher.Teacher_Firstname} {assignedTeacher.Teacher_Lastname} (ID: {assignedTeacher.Teacher_Id})");
                        }
                        else
                        {
                            Console.WriteLine("No teacher assigned to this course.");
                        }
                        break;
                    case "12":
                        Console.Write("Enter Enrollment ID: ");
                        int enrollmentId = int.Parse(Console.ReadLine());
                        Enrollment enrollment = studentSystem.GetEnrollmentById(enrollmentId);
                        if (enrollment != null)
                        {
                            Student student = studentSystem.GetEnrollmentStudent(enrollment);
                            if (student != null)
                            {
                                Console.WriteLine($"Student Info:");
                                Console.WriteLine($"ID: {student.Student_Id}");
                                Console.WriteLine($"Name: {student.Student_Firstname} {student.Student_Lastname}");
                                Console.WriteLine($"DOB: {student.Student_DOB.ToShortDateString()}");
                                Console.WriteLine($"Email: {student.Student_Email}");
                                Console.WriteLine($"Phone: {student.Student_Phone}");
                            }
                            else
                            {
                                Console.WriteLine("Student not found for this enrollment.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enrollment not found.");
                        }
                        break;

                    case "13":
                        Console.Write("Enter Enrollment ID: ");
                        enrollmentId = int.Parse(Console.ReadLine());
                        enrollment = studentSystem.GetEnrollmentById(enrollmentId);
                        if (enrollment != null)
                        {
                            Course course = studentSystem.GetEnrollmentCourse(enrollment);
                            if (course != null)
                            {
                                Console.WriteLine($"Course Info:");
                                Console.WriteLine($"ID: {course.Course_Id}");
                                Console.WriteLine($"Name: {course.Course_Name}");
                                Console.WriteLine($"Credits: {course.Credits}");
                                Console.WriteLine($"Teacher ID: {course.Teacher_Id}");
                            }
                            else
                            {
                                Console.WriteLine("Course not found for this enrollment.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enrollment not found.");
                        }
                        break;
                    case "14":
                        Console.Write("Enter Teacher ID: ");
                        teacherId = int.Parse(Console.ReadLine());
                        Console.Write("Enter column name to update (e.g., Teacher_Firstname): ");
                        string columnName = Console.ReadLine();
                        Console.Write("Enter new value: ");
                        string value = Console.ReadLine();
                        studentSystem.UpdateTeacherInfo(teacherId, columnName, value);
                        break;

                    case "15":
                        Console.Write("Enter Teacher ID: ");
                        teacherId = int.Parse(Console.ReadLine());
                        studentSystem.DisplayTeacherInfo(teacherId);
                        break;

                    case "16":
                        Console.Write("Enter Teacher ID: ");
                        teacherId = int.Parse(Console.ReadLine());
                        List<Course> assignedCourses = studentSystem.GetAssignedCourses(teacherId);
                        Console.WriteLine("Assigned Courses:");
                        foreach (var course in assignedCourses)
                        {
                            Console.WriteLine($"Course ID: {course.Course_Id}, Name: {course.Course_Name}");
                        }
                        break;
                    case "17":
                        Console.WriteLine("Enter Payment ID: ");
                        int paymentId = int.Parse(Console.ReadLine());
                        Student paymentStudent = studentSystem.GetPaymentStudent(paymentId);
                        if (paymentStudent != null)
                        {
                            Console.WriteLine($"Student Info:");
                            Console.WriteLine($"ID: {paymentStudent.Student_Id}");
                            Console.WriteLine($"Name: {paymentStudent.Student_Firstname} {paymentStudent.Student_Lastname}");
                            Console.WriteLine($"Email: {paymentStudent.Student_Email}");
                            Console.WriteLine($"Phone: {paymentStudent.Student_Phone}");
                        }
                        else
                        {
                            Console.WriteLine("No student found for this payment.");
                        }
                        break;
                    case "18":
                        Console.WriteLine("Enter Payment ID: ");
                        paymentId = int.Parse(Console.ReadLine());
                        int paymentAmount = studentSystem.GetPaymentAmount(paymentId);
                        Console.WriteLine($"Payment Amount: {paymentAmount}");
                        break;
                    case "19":
                        Console.WriteLine("Enter Payment ID: ");
                        paymentId = int.Parse(Console.ReadLine());
                        DateTime paymentDatee = studentSystem.GetPaymentDate(paymentId);
                        Console.WriteLine($"Payment Date: {paymentDatee.ToShortDateString()}");
                        break;

                    case "20":
                        exit = true;
                        break;
                  
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

                // Ask user if they want to continue or exit
                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Exiting the system. Goodbye!");
        }
    }
}
