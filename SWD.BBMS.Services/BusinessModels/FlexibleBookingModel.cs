using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FlexibleBookingModel
    {
        public int Id { get; set; }

        public float TotalHours { get; set; }

        public float RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }

        public BookingModelStatus Status { get; set; }

        public double? TotalCost { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public int CourtGroupId { get; set; }

        [JsonIgnore]
        public List<BookingModel>? Bookings { get; set; }
    }
}
