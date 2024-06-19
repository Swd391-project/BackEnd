using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IBookingService
    {
        Task<bool> SaveBooking(BookingModel bookingModel);
    }
}
