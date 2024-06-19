using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    public enum ContactType
    {
        [Display(Name = "Phone number")]
        PhoneNumber,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "Social page")]
        SocialPage
    }
}
