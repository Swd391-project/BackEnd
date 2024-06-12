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
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapUserStatusToUserModelStatus(src.Status)));
            CreateMap<UserModel, User>();
            
        }

        private UserModelStatus MapUserStatusToUserModelStatus(UserStatus status)
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
    }
}
