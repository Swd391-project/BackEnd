using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class CourtListResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Status {  get; set; }

        public DateTime CreatedDate { get; set; }

        public CourtGroup4CourtList CourtGroup { get; set; }
    }
}
