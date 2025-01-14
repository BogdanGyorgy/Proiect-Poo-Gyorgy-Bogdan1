namespace proiectul_1.Models
{
    // Loan.cs - Gestionarea împrumuturilor
    using System;

    public class Loan
    {
        public Client Borrower { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LoanDuration => (EndDate - StartDate).Days;

        // Proprietatea Price pentru prețul împrumutului
        public decimal Price => CalculateLoanPrice();

        // Constructor complet
        public Loan(Client borrower, Book borrowedBook, DateTime startDate, DateTime endDate)
        {
            Borrower = borrower;
            BorrowedBook = borrowedBook;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Constructor cu calcul automat al EndDate
        public Loan(Client borrower, Book borrowedBook)
        {
            Borrower = borrower;
            BorrowedBook = borrowedBook;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(borrowedBook.GetMaxLoanPeriod());
        }

        // Calcularea taxelor de întârziere
        public decimal CalculateLateFees()
        {
            if (DateTime.Now <= EndDate)
                return 0;

            int overdueDays = (DateTime.Now - EndDate).Days;
            decimal dailyFee = BorrowedBook is FictionBook ? 1m : 2m;

            return overdueDays * dailyFee;
        }

        // Calcularea prețului total al împrumutului
        public decimal CalculateLoanPrice()
        {
            return 60m * LoanDuration;
        }

        // Reprezentare detaliată sub formă de text
        public override string ToString()
        {
            return $"Împrumut: {BorrowedBook.Title} de la {StartDate:yyyy-MM-dd} până la {EndDate:yyyy-MM-dd} \n" +
                   $"Client: {Borrower.Name}, Durata: {LoanDuration} zile, Preț: {Price} RON, Taxă întârziere: {CalculateLateFees()} RON";
        }
    }
}
