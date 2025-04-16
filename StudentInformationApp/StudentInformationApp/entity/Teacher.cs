using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.entity
{
    public class Teacher
    {
        public int Teacher_Id { get; set; }
        public string Teacher_Firstname { get; set; }
        public string Teacher_Lastname { get; set; }
        public string Teacher_Email { get; set; }

        public Teacher()
        {

        }
        public Teacher(int teacher_Id, string firstName, string lastName, string email)
        {
            Teacher_Id = teacher_Id;
            Teacher_Firstname = firstName;
            Teacher_Lastname = lastName;
            Teacher_Email = email;
        }
    }
}
