using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.API.EnumParsers
{
    public class EnumParser
    {
        public static CourtModelStatus ParseCourtModelStatus(string statusStr)
        {
            if (Enum.TryParse(statusStr, true, out CourtModelStatus status))
            {
                return status;
            }
            throw new ArgumentException($"{statusStr} is not a valid CourtStatus");
        }

        public static CourtStatus ParseCourtStatus(string statusStr)
        {
            if (Enum.TryParse(statusStr, true, out CourtStatus status))
            {
                return status;
            }
            throw new ArgumentException($"{statusStr} is not a valid CourtStatus");
        }

        public static BookingModelStatus ParseBookingModelStatus(string statusStr)
        {
            if (Enum.TryParse(statusStr, true, out BookingModelStatus status))
            {
                return status;
            }
            throw new ArgumentException($"{statusStr} is not a valid BookingModelStatus");
        }
    }
}
