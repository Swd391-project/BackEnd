using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class BookingModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public DateOnly Date { get; set; }

        public string? Note { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }
        public TimeOnly? CheckinTime { get; set; }
        public TimeOnly? CheckoutTime { get; set; }

        public int? CheckinBy { get; set; }

        public int? CheckoutBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public CustomerModel Customer { get; set; }

        public List<BookingDetailModel> BookingDetails { get; set; }

        public PaymentModel? Payment { get; set; }

        public CourtModel Court { get; set; }

        public FlexibleBookingModel? FlexibleBooking { get; set; }

    }
}
