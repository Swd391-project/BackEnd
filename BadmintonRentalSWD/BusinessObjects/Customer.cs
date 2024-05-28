namespace BadmintonRentalSWD.BusinessObjects
{
    public class Customer
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email {  get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
