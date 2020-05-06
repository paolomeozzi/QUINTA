using System;

namespace LibraryDemo.Core
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int AffiliatedId { get; set; }
        public DateTime LoanDate { get; set; }
    }

    
}