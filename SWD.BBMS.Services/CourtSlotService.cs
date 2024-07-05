using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SWD.BBMS.Services
{
    public class CourtSlotService : ICourtSlotService
    {
        private readonly ICourtSlotRepository courtSlotRepository;

        private readonly ICourtRepository courtRepository;

        private readonly IMapper mapper;

        public CourtSlotService(ICourtSlotRepository courtSlotRepository, IMapper mapper, ICourtRepository courtRepository)
        {
            this.courtSlotRepository = courtSlotRepository;
            this.mapper = mapper;
            this.courtRepository = courtRepository;
        }

        public async Task<List<AvailableSlotModel>> GetAvailableCourtSlotsOfCourtGroupInDate(int courtGroupId, DateOnly date)
        {
            try
            {
                var courtSlots = await courtSlotRepository
                    .GetAvailableCourtSlotsByCourtGroupId(courtGroupId);
                var courtSlotModels = mapper.Map<List<CourtSlotModel>>(courtSlots);
                var courts = await courtRepository.GetCourtsByCourtGroupId(courtGroupId);
                var courtModels = mapper.Map<List<CourtModel>>(courts);
                var courtModelIds = courtModels.Select(c => c.Id).ToList();
                var availableSlotModels = new List<AvailableSlotModel>();
                foreach(var courtSlotModel in courtSlotModels)
                {
                    var availableSlotModel = mapper.Map<AvailableSlotModel>(courtSlotModel);
                    if (courtSlotModel.BookingDetails.IsNullOrEmpty())
                    {
                        availableSlotModel.Status = SlotModelStatus.Available;
                        availableSlotModels.Add(availableSlotModel);
                        continue;
                    }
                    var bookedCourtIds = new HashSet<int>();
                    foreach (var bookingDetailModel in courtSlotModel.BookingDetails)
                    {
                        if(bookingDetailModel.Booking.Date != date)
                        {
                            continue;
                        }
                        if (bookingDetailModel.Booking.Status == BookingModelStatus.Confirmed
                            || bookingDetailModel.Booking.Status == BookingModelStatus.InProgress)
                        {
                            bookedCourtIds.Add(bookingDetailModel.Booking.CourtId);
                        }
                    }
                    availableSlotModel.Status = bookedCourtIds.Count == courtModelIds.Count ? SlotModelStatus.Occupied : SlotModelStatus.Available;
                    availableSlotModels.Add(availableSlotModel);
                    continue;
                }
                return availableSlotModels;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CourtSlotModel>> GetCourtSlotsOfCourtGroup(int courtGroupId)
        {
            try
            {
                var courtSlots = await courtSlotRepository
                    .GetAvailableCourtSlotsByCourtGroupId(courtGroupId);
                var courtSlotModels = mapper.Map<List<CourtSlotModel>>(courtSlots);
                return courtSlotModels;
            }
            catch
            {
                throw;
            }
        }
    }
}
