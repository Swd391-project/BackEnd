using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public List<BookingModel> Bookings { get; set; }

        [JsonIgnore]
        public List<FlexibleBookingModel>? FlexibleBookings { get; set; }
    }
}
