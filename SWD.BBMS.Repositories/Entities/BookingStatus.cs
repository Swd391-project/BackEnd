using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    public enum BookingStatus
    {
        [Display(Name = "Confirmed")]
        Confirmed,
        [Display(Name = "Cancelled")]
        Cancelled,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Deleted")]
        Deleted
    }
}
