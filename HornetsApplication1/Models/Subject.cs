using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Result = new HashSet<Result>();
        }

        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string FacultyId { get; set; }
        public string ClassId { get; set; }

        public Class Class { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}
