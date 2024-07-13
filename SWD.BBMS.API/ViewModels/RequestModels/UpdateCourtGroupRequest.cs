namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class UpdateCourtGroupRequest
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public long? Price { get; set; } = 0;

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public string? ProfileImage { get; set; }

        public string? CoverImage { get; set; }
    }
}
