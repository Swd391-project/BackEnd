using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public enum CourtModelStatus
    {
        [Display(Name = "Available")]
        Available,
        [Display(Name = "Occupied")]
        Occupied,
        [Display(Name = "Closed")]
        Closed
    }
}
