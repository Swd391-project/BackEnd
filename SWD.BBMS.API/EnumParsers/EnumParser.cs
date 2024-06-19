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
    }
}
