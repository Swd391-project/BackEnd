using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Repositories.Parameters;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        private readonly ICourtGroupActivityRepository courtGroupActivityRepository;

        private readonly IMapper mapper;

        public CourtGroupService(
            ICourtGroupRepository courtGroupRepository, 
            IMapper mapper, 
            IWeekdayActivityRepository weekdayActivityRepository, 
            ICompanyRepository companyRepository, 
            ICourtSlotRepository courtSlotRepository, 
            ICourtRepository courtRepository, 
            ICourtGroupActivityRepository courtGroupActivityRepository
            )
        {
            this.courtGroupRepository = courtGroupRepository;
            this.mapper = mapper;
            this.weekdayActivityRepository = weekdayActivityRepository;
            this.companyRepository = companyRepository;
            this.courtSlotRepository = courtSlotRepository;
            this.courtRepository = courtRepository;
            this.courtGroupActivityRepository = courtGroupActivityRepository;
        }

        public async Task<bool> DeleteCourtGroup(int id)
        {
            var result = false;
            try
            {
                var courtGroup = await courtGroupRepository.FindCourtGroup(id);
                var courtGroupModel = mapper.Map<CourtGroupModel>(courtGroup);
                courtGroupModel.Status = CourtGroupModelStatus.Deleted;
                courtGroup = mapper.Map<CourtGroup>(courtGroupModel);
                result = await courtGroupRepository.UpdateCourtGroup(courtGroup);
            }
            catch
            {
                throw;
            }
            return result;
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

        public async Task<List<CourtGroupActivityModel>> GetAvailableDaysOfWeekForFixedBooking(int id, TimeOnly fromTime, TimeOnly toTime, int month, int year)
        {
            try
            {
                //var firstDayOfMonth = new DateOnly(year, month, 1);
                var courtSlots = await courtSlotRepository.GetAvailableCourtSlotsByCourtGroupId(id);
                var courtSlotModels = mapper.Map<List<CourtSlotModel>>(courtSlots);
                var courts = await courtRepository.GetCourtsByCourtGroupId(id);
                var courtModels = mapper.Map<List<CourtModel>>(courts);
                var occupiedDaysOfWeek = new List<string>();
                for(int i = 1; i <= 7; i++)
                {
                    var date = new DateOnly(year, month, i);
                    if(GetCourtIdAvailableForBookingOfCourtGroup(courtModels, date, fromTime, toTime) == 0)
                    {
                        occupiedDaysOfWeek.Add(date.DayOfWeek.GetDisplayName());
                    }
                }
                
                var courtGroupActivities = await courtGroupActivityRepository.GetCourtGroupActivitiesByCourtGroupId(id);
                var courtGroupAcivityModels = mapper.Map<List<CourtGroupActivityModel>>(courtGroupActivities);
                foreach(var activity in courtGroupAcivityModels)
                {
                    if (activity.ActivityStatus == ActivityModelStatus.Close)
                        continue;
                    if (occupiedDaysOfWeek.Contains(activity.WeekdayActivity.Weekday.GetDisplayName()))
                    {
                        activity.ActivityStatus = ActivityModelStatus.Close;
                    }
                }
                return courtGroupAcivityModels;
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

        public async Task<PagedList<CourtGroupModel>> GetCourtGroups(CourtGroupParameters courtGroupParameters)
        {
            var courtGroups = await courtGroupRepository.GetCourtGroups(courtGroupParameters);
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
                var closeTime = courtGroupModel.EndTime;
                var openTime = courtGroupModel.StartTime;
                var status = SlotStatus.Available;
                var price = courtGroupModel.PricePerHour / 2;
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

        public async Task<bool> UpdateCourtGroup(int id, Dictionary<string, object> courtGroupDictModel)
        {
            var result = false;
            try
            {
                var courtGroup = await courtGroupRepository.FindCourtGroup(id);
                if (courtGroup == null)
                {
                    throw new Exception("There is no user with id: " + id);
                }
                var courtGroupModel = mapper.Map<CourtGroupModel>(courtGroup);
                foreach (var dict in courtGroupDictModel)
                {
                    SetPropertyValueFromDictionary(courtGroupModel, dict);
                }
                courtGroup = mapper.Map<CourtGroup>(courtGroupModel);
                result = await courtGroupRepository.UpdateCourtGroup(courtGroup);

            }
            catch (Exception ex)
            {
                return false;
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

        private void SetPropertyValueFromDictionary(CourtGroupModel model, KeyValuePair<string, object> dict)
        {
            var property = model.GetType().GetProperty(dict.Key);
            if (property != null && property.CanWrite)
            {
                var propertyType = property.PropertyType;

                object value;

                if (dict.Value == null || dict.Value.Equals(""))
                {
                    return;
                }
                else if (propertyType.IsAssignableFrom(dict.Value.GetType()))
                {
                    value = dict.Value; // No conversion needed
                }
                else if (propertyType.IsEnum)
                {
                    // Handle enum conversion
                    value = Enum.Parse(propertyType, dict.Value.ToString());
                }
                else if (propertyType == typeof(Guid))
                {
                    // Handle Guid conversion
                    value = Guid.Parse(dict.Value.ToString());
                }
                else
                {
                    // Use JSON serialization/deserialization for complex types
                    var json = JsonSerializer.Serialize(dict.Value);
                    value = JsonSerializer.Deserialize(json, propertyType);
                    if (value == null || value.Equals(""))
                    {
                        return;
                    }
                }

                // Set the property value
                property.SetValue(model, value);
            }
        }

        private int GetCourtIdAvailableForBookingOfCourtGroup(List<CourtModel> courtModels, DateOnly date, TimeOnly fromTime, TimeOnly toTime)
        {
            try
            {
                foreach (var courtModel in courtModels)
                {
                    if (courtModel.Bookings.IsNullOrEmpty())
                    {
                        return courtModel.Id;
                    }
                    var isOccupied = false;
                    foreach (var bookingModel in courtModel.Bookings)
                    {
                        if (bookingModel.Date != date
                            || bookingModel.Status == BookingModelStatus.Cancelled
                            || bookingModel.Status == BookingModelStatus.Completed)
                        {
                            continue;
                        }
                        foreach (var bookingDetailModel in bookingModel.BookingDetails)
                        {
                            if (bookingDetailModel.CourtSlot.FromTime == fromTime
                                || bookingDetailModel.CourtSlot.ToTime == toTime
                                || (bookingDetailModel.CourtSlot.FromTime > fromTime && bookingDetailModel.CourtSlot.FromTime < toTime))
                            {
                                isOccupied = true;
                                break;
                            }
                        }
                        if (isOccupied)
                            break;
                    }
                    if (!isOccupied)
                    {
                        return courtModel.Id;
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateCourtGroupTimeAndPrice(int id, TimeOnly? startTime, TimeOnly? endTime, long pricePerHour)
        {
            var result = false;
            try
            {
                var courtGroup = await courtGroupRepository.GetCourtGroupById(id);
                if( courtGroup == null)
                {
                    throw new Exception($"Court group with id {id} not found in update court group time service.");
                }
                
                // Update court slot of court group
                
                var pricePerSlot = pricePerHour == 0 ? 0 : (long)((double)pricePerHour / 2);
                var courtSlots = await courtSlotRepository.GetCourtSlotsByCourtGroupId(id);
                startTime = startTime == null ? courtGroup.StartTime : startTime;
                endTime = endTime == null ? courtGroup.EndTime : endTime;
                if (endTime == new TimeOnly(0, 0))
                    endTime = new TimeOnly(23, 59);
                foreach(var courtSlot in courtSlots)
                {
                    if (startTime == new TimeOnly(0, 0) && endTime == new TimeOnly(23, 59))
                    {
                        courtSlot.Status = SlotStatus.Available;
                    }
                    else if( courtSlot.FromTime == startTime || courtSlot.ToTime == endTime || (courtSlot.FromTime > startTime && courtSlot.FromTime < endTime))
                    {
                        courtSlot.Status = SlotStatus.Available;
                    }
                    else
                    {
                        courtSlot.Status = SlotStatus.Closed;
                    }
                    if(pricePerSlot != 0)
                    {
                        courtSlot.Price = pricePerSlot;
                    }
                    var updateCourtSlotResult = await courtSlotRepository.UpdateCourtSlot(courtSlot);
                    if (!updateCourtSlotResult)
                    {
                        throw new Exception($"Something went wrong when update court slot in update court group time service.");
                    }
                }

                result = true;
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
