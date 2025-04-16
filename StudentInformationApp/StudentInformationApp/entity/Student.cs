using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.entity
{
    public class Student
    {
        public int Student_Id { get; set; }
        public string Student_Firstname { get; set; }
        public string Student_Lastname { get; set; }
        public DateTime Student_DOB { get; set; }
        public string Student_Email { get; set; }
        public long Student_Phone { get; set; }

        public Student() { }
        public Student(int student_Id, string firstName, string lastName, DateTime dob, string email, long phone)
        {
            Student_Id = student_Id;
            Student_Firstname = firstName;
            Student_Lastname = lastName;
            Student_DOB = dob;
            Student_Email = email;
            Student_Phone = phone;
        }
    }
}
