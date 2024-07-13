using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Libraries
{
    public class DateTimeLibrary
    {  
        public static DateTime UtcNow()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(configuration["TimeZoneId"]);
            var dateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            return dateTimeNow;
        }

        public static DateTime UtcNowToSave()
        {
            var localTime = UtcNow();
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(configuration["TimeZoneId"]);
            DateTime utcToSave = TimeZoneInfo.ConvertTimeToUtc(localTime, timeZoneById);
            return utcToSave;
        }
    }
}
