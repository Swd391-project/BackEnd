namespace BadmintonRentalSWD.BusinessObjects
{
    public class Court
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set;}

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public CourtGroup CourtGroup { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
