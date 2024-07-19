using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class BookingServiceModel
    {
        public int BookingId { get; set; }

        [JsonIgnore]
        public BookingModel Booking { get; set; }

        public int ServiceId { get; set; }

        public ServiceModel Service { get; set; }

        public int Quantity { get; set; }
    }
}
