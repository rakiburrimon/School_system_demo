using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Result
    {
        public string ResultId { get; set; }
        public string StudentId { get; set; }
        public string ClassId { get; set; }
        public string ExamId { get; set; }
        public string SubjectId { get; set; }
        public DateTime? Year { get; set; }
        public double? Grade { get; set; }

        public Class Class { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
