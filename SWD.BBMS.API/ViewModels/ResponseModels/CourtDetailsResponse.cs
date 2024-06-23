namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class CourtDetailsResponse
    {
        public int Id { get; set; }

        public string Status { get; set; } 
        
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set;}

        public string CourtGroupName {  get; set; }
    }
}
