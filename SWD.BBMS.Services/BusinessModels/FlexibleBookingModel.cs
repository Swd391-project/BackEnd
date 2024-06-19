using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FlexibleBookingModel
    {
        public int Id { get; set; }

        public int TotalHours { get; set; }

        public int RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public List<BookingModel>? Bookings { get; set; }
    }
}
