using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class BookingListResponse
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }

        public string Status { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }
    }
}
