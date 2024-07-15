using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Helpers
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICourtGroupRepository courtGroupRepository;
        private ISortHelper<CourtGroup> courtGroupSortHelper;
        private IBookingRepository bookingRepository;
        private ISortHelper<Booking> bookingSortHelper;

        public ICourtGroupRepository CourtGroup
        {
            get
            {
                if (courtGroupRepository == null)
                {
                    courtGroupRepository = new CourtGroupRepository(courtGroupSortHelper);
                }
                return courtGroupRepository;
            }
        }

        public IBookingRepository Booking
        {
            get
            {
                if (bookingRepository == null)
                {
                    bookingRepository = new BookingRepository(bookingSortHelper);
                }
                return bookingRepository;
            }
        }

        public RepositoryWrapper(ISortHelper<CourtGroup> courtGroupSortHelper, ISortHelper<Booking> bookingSortHelper)
        {
            this.courtGroupSortHelper = courtGroupSortHelper;
            this.bookingSortHelper = bookingSortHelper;
        }
    }
}
