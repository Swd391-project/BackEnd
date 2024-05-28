namespace BadmintonRentalSWD.BusinessObjects
{
    public class CourtSlot
    {
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public string Status { get; set; }

        public long Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public CourtGroup CourtGroup { get; set; }

        public ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
