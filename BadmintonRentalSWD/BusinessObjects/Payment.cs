namespace BadmintonRentalSWD.BusinessObjects
{
    public class Payment
    { 
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        public Company Company { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
