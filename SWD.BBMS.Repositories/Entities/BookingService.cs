using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("BookingService")]
    public class BookingService
    {
        [Key]
        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        [Key]
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int Quantity { get; set; }
    }
}
