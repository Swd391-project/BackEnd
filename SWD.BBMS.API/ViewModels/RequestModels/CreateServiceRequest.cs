namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class CreateServiceRequest
    {
        public string Name { get; set; }

        public long Price { get; set; }

        public string Unit { get; set; }

        public int CourtGroupId { get; set; }
    }
}
