namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class BookingPageResponse
    {
        public int Id { get; set; }

        public List<CourtSlotBookingPage>? CourtSlots { get; set; }

        public List<CourtBookingPage>? Courts { get; set; }
    }
}
