using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BackgroundServices
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public MyBackgroundService(ILogger<MyBackgroundService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MyBackgroundService is starting.");

            stoppingToken.Register(() =>
                _logger.LogInformation("MyBackgroundService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("MyBackgroundService task doing background work.");

                using (var scope = _scopeFactory.CreateScope())
                {
                    var bookingRepository = scope.ServiceProvider.GetRequiredService<IBookingRepository>();
                    var currentDate = DateTimeLibrary.UtcNow();
                    var currentDateOnly = DateOnly.FromDateTime(currentDate);
                    var currentTimeOnly = TimeOnly.FromDateTime(currentDate);

                    var bookings = await bookingRepository.GetAllBookingsByStatusAndDate(BookingStatus.Confirmed, currentDateOnly);
                    if (!bookings.IsNullOrEmpty())
                    {
                        foreach (var booking in bookings)
                        {
                            var isCancelled = false;
                            if (booking.ToTime <= currentTimeOnly)
                            {
                                if (!booking.IsPaid)
                                {
                                    booking.Status = BookingStatus.Cancelled;
                                    await bookingRepository.UpdateBooking(booking);
                                    _logger.LogInformation($"Booking with id {booking.Id}'s status is updated to Cancelled.");
                                    continue;
                                }
                                isCancelled = true;
                            }
                            else if (booking.FromTime < currentTimeOnly)
                            {
                                
                                var difference = currentTimeOnly - booking.FromTime;
                                var totalMinutes = difference.TotalMinutes;
                                if (totalMinutes > 15)
                                {
                                    if (!booking.IsPaid)
                                    {
                                        booking.Status = BookingStatus.Cancelled;
                                        await bookingRepository.UpdateBooking(booking);
                                        _logger.LogInformation($"Booking with id {booking.Id}'s status is updated to Cancelled.");
                                        continue;
                                    }
                                }
                            }
                            if (isCancelled)
                            {
                                booking.Status = BookingStatus.Expired;
                                await bookingRepository.UpdateBooking(booking);
                                _logger.LogInformation($"Booking with id {booking.Id}'s status is updated to Expired.");
                            }

                        }
                    }

                    var inProgressBookings = await bookingRepository.GetAllBookingsByStatusAndDate(BookingStatus.InProgress, currentDateOnly);
                    foreach(var booking in inProgressBookings)
                    {
                        var isCompleted = false;
                        if (booking.ToTime <= currentTimeOnly)
                        {
                            isCompleted = true;
                        }
                        if (isCompleted)
                        {
                            booking.Status = BookingStatus.Completed;
                            await bookingRepository.UpdateBooking(booking);
                            _logger.LogInformation($"Booking with id {booking.Id}'s status is updated to Completed.");
                        }
                    }
                }

                
                // Perform background work here.
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("MyBackgroundService background task is stopping.");
        }
    }
}
