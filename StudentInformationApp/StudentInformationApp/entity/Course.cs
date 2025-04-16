using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.entity
{
    public class Course
    {
        public int Course_Id { get; set; }
        public string Course_Name { get; set; }
        public int Credits { get; set; }
        public int Teacher_Id { get; set; }  // FK to Teacher

        public Course() { }
        public Course(int course_Id, string name, int credits, int teacher_Id)
        {
            Course_Id = course_Id;
            Course_Name = name;
            Credits = credits;
            Teacher_Id = teacher_Id;
        }
    }
}
