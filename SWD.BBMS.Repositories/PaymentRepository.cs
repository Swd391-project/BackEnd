﻿using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<bool> SavePayment(Payment payment)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                var bookings = payment.Bookings;
                payment.Bookings = new List<Booking>();
                if(!bookings.IsNullOrEmpty())
                {
                    foreach(var booking in bookings)
                    {
                        payment.Bookings.Add(await dbContext.Bookings.FindAsync(booking.Id));
                    }
                }
                await dbContext.AddAsync(payment);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}