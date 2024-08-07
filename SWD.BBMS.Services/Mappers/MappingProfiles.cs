﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Booking, BookingModel>()
                //.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                ;
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToUserModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToUserStatus(src.Status)));

            CreateMap<CourtGroup, CourtGroupModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtGroupModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtGroupStatus(src.Status)));

            CreateMap<Court, CourtModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtStatus(src.Status)));

            CreateMap<CourtSlot, CourtSlotModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToSlotModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToSlotStatus(src.Status)));

            CreateMap<CourtSlotModel, SlotModel>()
                .ReverseMap();

            CreateMap<CourtSlotModel, AvailableSlotModel>()
                .ReverseMap();

            CreateMap<CourtGroupActivity, CourtGroupActivityModel>()
                .ForMember(dest => dest.ActivityStatus, opt => opt.MapFrom(src => MapToActivityModelStatus(src.ActivityStatus)))
                .ReverseMap()
                .ForMember(dest => dest.ActivityStatus, opt => opt.MapFrom(src => MapToActivityStatus(src.ActivityStatus)));

            CreateMap<WeekdayActivity, WeekdayActivityModel>()
                .ForMember(dest => dest.Weekday, opt => opt.MapFrom(src => MapToWeekdayModel(src.Weekday)))
                .ReverseMap()
                .ForMember(dest => dest.Weekday, opt => opt.MapFrom(src => MapToWeekday(src.Weekday)));

            CreateMap<Booking, BookingModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToBookingModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToBookingStatus(src.Status)));

            CreateMap<Customer, CustomerModel>()
                .ReverseMap();

            CreateMap<BookingDetail, BookingDetailModel>()
                .ReverseMap();

            CreateMap<BookingType, BookingTypeModel>()
                .ReverseMap();

            CreateMap<Payment, PaymentModel>()
                .ReverseMap();

            CreateMap<PaymentMethod, PaymentMethodModel>()
                .ReverseMap();

            CreateMap<FlexibleBooking, FlexibleBookingModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToBookingModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToBookingStatus(src.Status)));

            CreateMap<Company, CompanyModel>()
                .ReverseMap();

            CreateMap<Service, ServiceModel>()
                .ReverseMap();

            CreateMap<Feedback, FeedbackModel>()
                .ReverseMap();

            CreateMap<FileRecord, FileRecordModel>()
                .ReverseMap();

        }

        private UserModelStatus MapToUserModelStatus(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.Active:
                    return UserModelStatus.Active;
                case UserStatus.Inactive:
                    return UserModelStatus.Inactive;
                case UserStatus.Closed:
                    return UserModelStatus.Closed;
                case UserStatus.Deleted:
                    return UserModelStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled user status.");
            }
        }

        private UserStatus MapToUserStatus(UserModelStatus status)
        {
            switch (status)
            {
                case UserModelStatus.Active:
                    return UserStatus.Active;
                case UserModelStatus.Inactive:
                    return UserStatus.Inactive;
                case UserModelStatus.Closed:
                    return UserStatus.Closed;
                case UserModelStatus.Deleted:
                    return UserStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled user status.");
            }
        }

        private ActivityModelStatus MapToActivityModelStatus(ActivityStatus status)
        {
            switch (status)
            {
                case ActivityStatus.Open:
                    return ActivityModelStatus.Open;
                case ActivityStatus.Close:
                    return ActivityModelStatus.Close;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled activity status.");
            }
        }

        private ActivityStatus MapToActivityStatus(ActivityModelStatus status)
        {
            switch (status)
            {
                case ActivityModelStatus.Open:
                    return ActivityStatus.Open;
                case ActivityModelStatus.Close:
                    return ActivityStatus.Close;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled activity status.");
            }
        }

        private WeekdayModel MapToWeekdayModel(Weekday status)
        {
            switch (status)
            {
                case Weekday.Monday:
                    return WeekdayModel.Monday;
                case Weekday.Tuesday:
                    return WeekdayModel.Tuesday;
                case Weekday.Wednesday:
                    return WeekdayModel.Wednesday;
                case Weekday.Thursday:
                    return WeekdayModel.Thursday;
                case Weekday.Friday:
                    return WeekdayModel.Friday;
                case Weekday.Saturday:
                    return WeekdayModel.Saturday;
                case Weekday.Sunday:
                    return WeekdayModel.Sunday;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled weekday.");
            }
        }

        private Weekday MapToWeekday(WeekdayModel status)
        {
            switch (status)
            {
                case WeekdayModel.Monday:
                    return Weekday.Monday;
                case WeekdayModel.Tuesday:
                    return Weekday.Tuesday;
                case WeekdayModel.Wednesday:
                    return Weekday.Wednesday;
                case WeekdayModel.Thursday:
                    return Weekday.Thursday;
                case WeekdayModel.Friday:
                    return Weekday.Friday;
                case WeekdayModel.Saturday:
                    return Weekday.Saturday;
                case WeekdayModel.Sunday:
                    return Weekday.Sunday;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled weekday.");
            }
        }

        private CourtModelStatus MapToCourtModelStatus(CourtStatus status)
        {
            switch (status)
            {
                case CourtStatus.Available:
                    return CourtModelStatus.Available;
                case CourtStatus.Occupied:
                    return CourtModelStatus.Occupied;
                case CourtStatus.Closed:
                    return CourtModelStatus.Closed;
                case CourtStatus.Deleted:
                    return CourtModelStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court status.");
            }
        }

        private CourtStatus MapToCourtStatus(CourtModelStatus status)
        {
            switch (status)
            {
                case CourtModelStatus.Available:
                    return CourtStatus.Available;
                case CourtModelStatus.Occupied:
                    return CourtStatus.Occupied;
                case CourtModelStatus.Closed:
                    return CourtStatus.Closed;
                case CourtModelStatus.Deleted:
                    return CourtStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court status.");
            }
        }

        private SlotModelStatus MapToSlotModelStatus (SlotStatus status)
        {
            switch (status)
            {
                case SlotStatus.Available:
                    return SlotModelStatus.Available;
                case SlotStatus.Closed:
                    return SlotModelStatus.Closed;
                case SlotStatus.Occupied:
                    return SlotModelStatus.Occupied;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court slot status.");
            }
        }

        private SlotStatus MapToSlotStatus(SlotModelStatus status)
        {
            switch (status)
            {
                case SlotModelStatus.Available:
                    return SlotStatus.Available;
                case SlotModelStatus.Closed:
                    return SlotStatus.Closed;
                case SlotModelStatus.Occupied:
                    return SlotStatus.Occupied;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court slot status.");
            }
        }

        private BookingStatus MapToBookingStatus(BookingModelStatus status)
        {
            switch (status)
            {
                case BookingModelStatus.Confirmed:
                    return BookingStatus.Confirmed;
                case BookingModelStatus.Cancelled:
                    return BookingStatus.Cancelled;
                case BookingModelStatus.InProgress:
                    return BookingStatus.InProgress;
                case BookingModelStatus.Completed:
                    return BookingStatus.Completed;
                case BookingModelStatus.Deleted:
                    return BookingStatus.Deleted;
                case BookingModelStatus.Expired:
                    return BookingStatus.Expired;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled booking status.");
            }
        }

        private BookingModelStatus MapToBookingModelStatus(BookingStatus status)
        {
            switch (status)
            {
                case BookingStatus.Confirmed:
                    return BookingModelStatus.Confirmed;
                case BookingStatus.Cancelled:
                    return BookingModelStatus.Cancelled;
                case BookingStatus.InProgress:
                    return BookingModelStatus.InProgress;
                case BookingStatus.Completed:
                    return BookingModelStatus.Completed;
                case BookingStatus.Deleted:
                    return BookingModelStatus.Deleted;
                case BookingStatus.Expired:
                    return BookingModelStatus.Expired;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled booking status.");
            }
        }

        private CourtGroupModelStatus MapToCourtGroupModelStatus(CourtGroupStatus status)
        {
            switch (status)
            {
                case CourtGroupStatus.Open:
                    return CourtGroupModelStatus.Open;
                case CourtGroupStatus.Closed:
                    return CourtGroupModelStatus.Closed;
                case CourtGroupStatus.Deleted:
                    return CourtGroupModelStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court group status.");
            }
        }

        private CourtGroupStatus MapToCourtGroupStatus(CourtGroupModelStatus status)
        {
            switch (status)
            {
                case CourtGroupModelStatus.Open:
                    return CourtGroupStatus.Open;
                case CourtGroupModelStatus.Closed:
                    return CourtGroupStatus.Closed;
                case CourtGroupModelStatus.Deleted:
                    return CourtGroupStatus.Deleted;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court group status.");
            }
        }
    }
}
