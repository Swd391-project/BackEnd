using AutoMapper;
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
                //.ForMember(dest => dest.BookingDetails, opt => opt.MapFrom(src => src.BookingDetails))
                //.ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                //.ForMember(dest => dest.Court, opt => opt.MapFrom(src => src.Court))
                //.ForMember(dest => dest.FlexibleBooking, opt => opt.MapFrom(src => src.FlexibleBooking))
                ;
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToUserModelStatus(src.Status)));
            CreateMap<UserModel, User>();
            //CreateMap<CourtGroupModel, CourtGroup>();
            CreateMap<CourtGroup, CourtGroupModel>().ReverseMap();
            //CreateMap<CourtModel, Court>();
            CreateMap<Court, CourtModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtModelStatus(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToCourtStatus(src.Status)));
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unhandled court status.");
            }
        }
    }
}
