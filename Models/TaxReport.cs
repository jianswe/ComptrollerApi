using System;

namespace ComptrollerApi.Models
{
    public class TaxReport
    {
        public int Id { get; set; }
        public string TaxId { get; set; } // Associated Business Tax ID
        public string Category { get; set; } // Associated Business Tax ID
        public decimal Revenue { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string Status { get; set; } // e.g. Pending, Approved, Rejected
    }
}
