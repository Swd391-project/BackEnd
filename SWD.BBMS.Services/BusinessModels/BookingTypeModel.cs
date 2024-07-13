using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SWD.BBMS.Services.BusinessModels
{
    public class BookingTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [JsonIgnore]
        public List<BookingModel>? Bookings { get; set; }

        [JsonIgnore]
        public List<PriceModel>? Prices { get; set; }
    }
}
