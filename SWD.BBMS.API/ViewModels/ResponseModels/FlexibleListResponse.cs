namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class FlexibleListResponse
    {
        public int Id { get; set; }

        public float TotalHours { get; set; }

        public float RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }
    }
}
