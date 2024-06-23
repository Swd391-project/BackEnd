using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    public enum SlotStatus
    {
        [Display(Name = "Available")]
        Available,
        [Display(Name = "Closed")]
        Closed,
        [Display(Name = "Occupied")]
        Occupied
    }
}
