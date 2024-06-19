namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class CourtGroupDetailsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public float? Rate { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string? ProfileImage { get; set; }

        public string? CoverImage { get; set; }

        public List<WeekdayActivityCourtGroupDetails>? WeekdayActivities { get; set; }
    }
}
