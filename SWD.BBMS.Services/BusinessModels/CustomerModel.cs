using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public List<BookingModel> Bookings { get; set; }

        public List<FlexibleBookingModel>? FlexibleBookings { get; set; }
    }
}
