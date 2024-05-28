namespace BadmintonRentalSWD.BusinessObjects
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public string Unit { get; set; }

        public CourtGroup CourtGroup { get; set; }
    }
}
