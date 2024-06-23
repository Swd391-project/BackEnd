namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class FlexibleListResponse
    {
        public int Id { get; set; }

        public int TotalHours { get; set; }

        public int RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }
    }
}
