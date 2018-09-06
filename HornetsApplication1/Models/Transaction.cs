using System;
using System.Collections.Generic;

namespace HornetsApplication1.Models
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public string StudentId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public double? TransactionAmount { get; set; }

        public Student Student { get; set; }
    }
}
