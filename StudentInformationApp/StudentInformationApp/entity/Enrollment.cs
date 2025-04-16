using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.entity
{
    public class Enrollment
    {
        public int Enrollment_Id { get; set; }
        public int Student_Id { get; set; }    // FK to Student
        public int Course_Id { get; set; }     // FK to Course
        public DateTime Enrollment_Date { get; set; }

        public Enrollment() { }
        public Enrollment(int enrollment_Id, int student_Id, int course_Id, DateTime enrollmentDate)
        {
            Enrollment_Id = enrollment_Id;
            Student_Id = student_Id;
            Course_Id = course_Id;
            Enrollment_Date = enrollmentDate;
        }
    }
}
