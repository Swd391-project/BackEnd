using AutoMapper;
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
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
