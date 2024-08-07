﻿using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using SWD.BBMS.Services.Libraries;

namespace BadmintonRentalSWD
{
    public class Seed
    {
        private readonly BBMSDbContext dbContext;

        private readonly UserManager<User> userManager;

        public Seed(BBMSDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void SeedDataContext()
        {
            
            if (!dbContext.PaymentMethods.Any())
            {
                var paymentMethod1 = new PaymentMethod
                {
                    MethodName = "Banking",
                    Description = "ashfksajhfskf",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    CreatedDate = DateTimeLibrary.UtcNowToSave(),
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedDate = DateTimeLibrary.UtcNowToSave(),
                };
                dbContext.PaymentMethods.AddRange(paymentMethod1);

                var paymentMethod2 = new PaymentMethod
                {
                    MethodName = "Cash",
                    Description = "ashfksajhfskf",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    CreatedDate = DateTimeLibrary.UtcNowToSave(),
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedDate = DateTimeLibrary.UtcNowToSave(),
                };
                dbContext.PaymentMethods.AddRange(paymentMethod2);

                var paymentMethod3 = new PaymentMethod
                {
                    MethodName = "VnPay",
                    Description = "ashfksajhfskf",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    CreatedDate = DateTimeLibrary.UtcNowToSave(),
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedDate = DateTimeLibrary.UtcNowToSave(),
                };
                dbContext.PaymentMethods.AddRange(paymentMethod3);

                var paymentMethod4 = new PaymentMethod
                {
                    MethodName = "Momo",
                    Description = "ashfksajhfskf",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    CreatedDate = DateTimeLibrary.UtcNowToSave(),
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedDate = DateTimeLibrary.UtcNowToSave(),
                };
                dbContext.PaymentMethods.AddRange(paymentMethod4);

                dbContext.SaveChanges();
            }
            
            if (!dbContext.WeekdayActivities.Any())
            {
                var values = Enum.GetValues(typeof(Weekday));
                var weekdays = values.Cast<Weekday>().ToList();
                foreach(var weekday in weekdays)
                {
                    var weekdayActivity = new WeekdayActivity
                    {
                        Weekday = weekday
                    };
                    dbContext.WeekdayActivities.Add(weekdayActivity);
                }
                dbContext.SaveChanges();
            }
            if (!dbContext.Companies.Any())
            {
                var company = new Company
                {
                    Name = "PACK",
                    Balance = 100000000,
                    PhoneNumber = "1122334455",
                    Email = "pack@bbms.com"
                };
                dbContext.Companies.Add(company);
                dbContext.SaveChanges();
            }
            if (!dbContext.BookingTypes.Any())
            {
                var bookingType1 = new BookingType
                {
                    Name = "Daily",
                    Description = "This type allows users to reserve a badminton court for a single day.",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                };
                dbContext.BookingTypes.Add(bookingType1);

                var bookingType2 = new BookingType
                {
                    Name = "Fixed",
                    Description = "This booking type is for users who want to secure a court over a prolonged period, typically for a season or several months.",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                };
                dbContext.BookingTypes.Add(bookingType2);

                var bookingType3 = new BookingType
                {
                    Name = "Flexible",
                    Description = "In this model, users purchase a bundle of hours upfront and can use these hours to book court time flexibly.",
                    CreatedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    ModifiedBy = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                };
                dbContext.BookingTypes.Add(bookingType3);
                dbContext.SaveChanges();
            }
        }
    }
}
