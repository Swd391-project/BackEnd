﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.Entities
{
    [Table("FlexibleBooking")]
    public class FlexibleBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TotalHours { get; set; }

        public int RemainingHours { get; set; }

        public DateOnly IssuedDate { get; set; }

        public DateOnly ExpiredDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}