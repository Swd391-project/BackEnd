using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CourtModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public CourtGroupModel CourtGroup { get; set; }

        public List<BookingModel>? Bookings { get; set; }
    }
}
