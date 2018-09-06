using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Student
    {
        public Student()
        {
            Result = new HashSet<Result>();
            Transaction = new HashSet<Transaction>();
        }

        public string StudentId { get; set; }
        public string Password { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }

        public ICollection<Result> Result { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
