namespace BadmintonRentalSWD.BusinessObjects
{
    public class Withdraw
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public Company Company { get; set; }
    }
}
