using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class CourtSlotBookingPage
    {
        public int Id { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public string Status { get; set; }

        public long Price { get; set; }
    }
}
