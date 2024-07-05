using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IFlexibleBookingRepository
    {
        Task<List<FlexibleBooking>> GetFlexibleBookingByCustomerIdAndCourtGroupIdAndMonth(int customerId, int courtGroupId, int month);

        Task<bool> UpdateFlexibleBooking(FlexibleBooking flexibleBooking);

        Task<bool> DeleteFlexibleBooking(FlexibleBooking flexibleBooking);

        Task<bool> SaveFlexibleBooking(FlexibleBooking flexibleBooking);
    }
}
