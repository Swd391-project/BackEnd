namespace BadmintonRentalSWD.BusinessObjects
{
    public class BookingDetail
    {

        public int Id { get; set; }

        //public int BookingId { get; set; }

        public Booking Booking { get; set; }

        //public int CourtSlotId {  get; set; }

        public CourtSlot CourtSlot { get; set; }
    }
}
