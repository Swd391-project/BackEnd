namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateFeedbackRequest
    {
        public string? Content { get; set; }

        public float? Rate { get; set; }

        public int CourtGroupId { get; set; }
    }
}
