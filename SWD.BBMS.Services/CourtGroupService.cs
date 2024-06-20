using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class CourtGroupService : ICourtGroupService
    {
        private readonly ICourtGroupRepository courtGroupRepository;

        private readonly IWeekdayActivityRepository weekdayActivityRepository;

        private readonly ICompanyRepository companyRepository;

        private readonly ICourtSlotRepository courtSlotRepository;

        private readonly ICourtRepository courtRepository;

        private readonly IMapper mapper;

        public CourtGroupService(ICourtGroupRepository courtGroupRepository, IMapper mapper, IWeekdayActivityRepository weekdayActivityRepository, ICompanyRepository companyRepository, ICourtSlotRepository courtSlotRepository, ICourtRepository courtRepository)
        {
            this.courtGroupRepository = courtGroupRepository;
            this.mapper = mapper;
            this.weekdayActivityRepository = weekdayActivityRepository;
            this.companyRepository = companyRepository;
            this.courtSlotRepository = courtSlotRepository;
            this.courtRepository = courtRepository;
        }

        public async Task<List<AvailableCourtSLotModel>> GetAvailableCourtSlotInDate(int id, DateOnly date)
        {
            try
            {
                var courtSlots = await courtSlotRepository.GetAvailableCourtSlotsByCourtGroupId(id);
                var courtSlotModels = mapper.Map<List<CourtSlotModel>>(courtSlots);
                var courts = await  courtRepository.GetCourtsByCourtGroupId(id);
                var courtModels = mapper.Map<List<CourtModel>>(courts);
                var availableCourtSlots = new List<AvailableCourtSLotModel>();
                foreach (var courtModel in courtModels)
                {
                    if (!courtModel.Bookings.IsNullOrEmpty())
                    {
                        var bookingDates = courtModel?.Bookings?.Select(b => b.Date).ToList();
                        if (!bookingDates.Contains(date))
                        {
                            foreach (var courtSlotModel in courtSlotModels)
                            {
                                var availableCourtSlot = new AvailableCourtSLotModel
                                {
                                    CourtId = courtModel.Id,
                                    CourtSlotId = courtSlotModel.Id,
                                    CourtSlot = mapper.Map<SlotModel>(courtSlotModel),
                                    Status = CourtModelStatus.Available
                                };
                                availableCourtSlots.Add(availableCourtSlot);
                            }
                            continue;
                        }
                        foreach (var bookingModel in courtModel.Bookings)
                        {

                            if (bookingModel.Date != date)
                            {
                                continue;
                            }
                            if (bookingModel.Status == BookingModelStatus.Cancelled
                                || bookingModel.Status == BookingModelStatus.Completed)
                            {
                                continue;
                            }
                            var slotIds = new List<int>();
                            foreach (var bookingDetailModel in bookingModel.BookingDetails)
                            {
                                var availableCourtSlot = new AvailableCourtSLotModel
                                {
                                    CourtId = courtModel.Id,
                                    CourtSlotId = bookingDetailModel.CourtSlotId,
                                    CourtSlot = mapper.Map<SlotModel>(bookingDetailModel.CourtSlot),
                                    Status = CourtModelStatus.Occupied
                                };
                                availableCourtSlots.Add(availableCourtSlot);
                                slotIds.Add(bookingDetailModel.CourtSlotId);
                            }
                            foreach(var courtSlotModel in courtSlotModels)
                            {
                                if (slotIds.Contains(courtSlotModel.Id))
                                {
                                    continue;
                                }
                                var availableCourtSlot = new AvailableCourtSLotModel
                                {
                                    CourtId = courtModel.Id,
                                    CourtSlotId = courtSlotModel.Id,
                                    CourtSlot = mapper.Map<SlotModel>(courtSlotModel),
                                    Status = CourtModelStatus.Available
                                };
                                availableCourtSlots.Add(availableCourtSlot);
                            }
                        }
                    }
                    else
                    {
                        foreach (var courtSlotModel in courtSlotModels)
                        {
                            var availableCourtSlot = new AvailableCourtSLotModel
                            {
                                CourtId = courtModel.Id,
                                CourtSlotId = courtSlotModel.Id,
                                CourtSlot = mapper.Map<SlotModel>(courtSlotModel),
                                Status = CourtModelStatus.Available
                            };
                            availableCourtSlots.Add(availableCourtSlot);
                        }
                    }
                }
                return availableCourtSlots;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CourtGroupModel> GetCourtGroupById(int id)
        {
            try
            {
                var courtGroup = await courtGroupRepository.GetCourtGroupById(id);
                var courtGroupModel = mapper.Map<CourtGroupModel>(courtGroup);   
                return courtGroupModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<CourtGroupModel>> GetCourtGroups(int pageNumber, int pageSize)
        {
            var courtGroups = await courtGroupRepository.GetCourtGroups(pageNumber, pageSize);
            var courtGroupModels = mapper.Map<PagedList<CourtGroupModel>>(courtGroups);
            return new PagedList<CourtGroupModel>(courtGroupModels, courtGroups.TotalCount, courtGroups.CurrentPage, courtGroups.PageSize);
        }

        public async Task<bool> SaveCourtGroup(CourtGroupModel courtGroupModel)
        {
            var result = false;
            try
            {
                var courtGroup = mapper.Map<CourtGroup>(courtGroupModel);
                //Week day activities
                var weekdayActivities = await weekdayActivityRepository.GetWeekdayActivities();
                courtGroup.CourtGroupActivities = new List<CourtGroupActivity>();
                foreach (var weekdayActivity in weekdayActivities)
                {
                    var courtGroupActivity = new CourtGroupActivity
                    {
                        CourtGroup = courtGroup, WeekdayActivityId = weekdayActivity.Id, ActivityStatus = ActivityStatus.Open
                    };
                    courtGroup.CourtGroupActivities.Add(courtGroupActivity);
                }
                //Company
                var companies = await companyRepository.GetCompanies();
                courtGroup.CompanyId = companies.First().Id;
                //Court slots
                courtGroup.CourtSlots = new List<CourtSlot>();
                var time = new TimeOnly(0, 0);
                var closeTime = courtGroupModel.EndTime == time ? new TimeOnly(23, 59) : courtGroupModel.EndTime;
                var openTime = courtGroupModel.StartTime;
                var status = SlotStatus.Available;
                var price = (long)100000;
                do
                {
                    var courtSlot = new CourtSlot();
                    courtSlot.FromTime = time;
                    courtSlot.ToTime = time.AddMinutes(30);
                    courtSlot.Status = GetCourtSlotStatus(openTime, closeTime, time);
                    courtSlot.Price = price;
                    courtSlot.CreatedBy = courtGroupModel.CreatedBy;
                    courtSlot.ModifiedBy = courtGroupModel.ModifiedBy;
                    courtSlot.CourtGroup = courtGroup;
                    courtGroup.CourtSlots.Add(courtSlot);
                    time = time.AddMinutes(30);
                } while (time != new TimeOnly(0, 0));
                result = await courtGroupRepository.SaveCourtGroup(courtGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        private SlotStatus GetCourtSlotStatus(TimeOnly openTime, TimeOnly closeTime, TimeOnly time)
        {
            if (openTime == closeTime)
                return SlotStatus.Available;
            if (closeTime == new TimeOnly(0, 0))
            {
                closeTime = new TimeOnly(23, 59);
            }
            if (time >= openTime && time < closeTime)
            {
                return SlotStatus.Available;
            }
            return SlotStatus.Closed;
        }
    }
}
