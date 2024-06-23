using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public enum CourtGroupModelStatus
    {
        [Display(Name = "Open")]
        Open,
        [Display(Name = "Closed")]
        Closed,
        [Display(Name = "Deleted")]
        Deleted,
    }
}
