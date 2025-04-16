using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.entity
{
    public class Payment
    {
        public int Payment_Id { get; set; }
        public int Student_Id { get; set; }     // FK to Student
        public int Amount { get; set; }
        public DateTime Payment_Date { get; set; }
        public Payment() { }
        public Payment(int payment_Id, int student_Id, int amount, DateTime paymentDate)
        {
            Payment_Id = payment_Id;
            Student_Id = student_Id;
            Amount = amount;
            Payment_Date = paymentDate;
        }
    }
}
