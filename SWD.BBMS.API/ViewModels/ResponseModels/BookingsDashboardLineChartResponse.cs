namespace SWD.BBMS.API.ViewModels.ResponseModels
{
    public class BookingsDashboardLineChartResponse
    {
        public string Month { get; set; }
        public List<CourtListLineChart> courtGroups { get; set; }
    }
}
