using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Class
    {
        public Class()
        {
            Result = new HashSet<Result>();
            Subject = new HashSet<Subject>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<Result> Result { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
