using System;
using System.Collections.Generic;
using StudentInformationSystem.entity;

namespace StudentInformationSystem
{
    public interface IStudentInformationSystem
    {
        // STUDENT methods
        void EnrollInCourse(int studentId, int courseId);
        void UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dob, string email, long phone);
        void MakePayment(int studentId, decimal amount, DateTime paymentDate);
        void DisplayStudentInfo(int studentId);
        List<Course> GetEnrolledCourses(int studentId);
        List<Payment> GetPaymentHistory(int studentId);

        //// COURSE methods
        void AssignTeacherToCourse(int teacherId, int courseId);
        void UpdateCourseInfo(int courseId, string courseCode, string courseName);
        void DisplayCourseInfo(int courseId);
        List<Enrollment> GetEnrollments(int courseId);
        Teacher GetAssignedTeacher(int courseId);

        //// ENROLLMENT methods
        Enrollment GetEnrollmentById(int enrollmentId);

        Student GetEnrollmentStudent(Enrollment enrollment);
        Course GetEnrollmentCourse(Enrollment enrollment);

        //// TEACHER methods
        // Update Teacher Info by column name
        void UpdateTeacherInfo(int teacherId, string columnName, object value);

        // Display Teacher Info by Teacher ID
        void DisplayTeacherInfo(int teacherId);

        // Get Assigned Courses by Teacher ID
        List<Course> GetAssignedCourses(int teacherId);

        //// PAYMENT methods
        Student GetPaymentStudent(int paymentId);

        // Method to get the Payment Amount
        int GetPaymentAmount(int paymentId);

        // Method to get the Payment Date
        DateTime GetPaymentDate(int paymentId);


    }
}
