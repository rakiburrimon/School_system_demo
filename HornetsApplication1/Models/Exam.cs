using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Result = new HashSet<Result>();
        }

        public string ExamId { get; set; }
        public string ExamName { get; set; }

        public ICollection<Result> Result { get; set; }
    }
}
