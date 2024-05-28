namespace BadmintonRentalSWD.BusinessObjects
{
    public class Booking
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }

        public string Status { get; set; }  

        public string Type { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public TimeOnly? CheckinTime { get; set; }

        public TimeOnly? CheckoutTime { get; set; }

        public int? CheckinBy { get; set; }

        public int? CheckoutBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public Customer Customer { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }

        public Payment Payment { get; set; }

        public Court Court { get; set; }

    }
}
