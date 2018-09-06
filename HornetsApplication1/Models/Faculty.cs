using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Subject = new HashSet<Subject>();
        }

        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Password { get; set; }
        public string FacultyDesignation { get; set; }
        public string FacultyQualification { get; set; }
        public string FacultyAddress { get; set; }
        public string FacultyContact { get; set; }
        public string FacultyImage { get; set; }

        public ICollection<Subject> Subject { get; set; }
    }
}
