namespace BadmintonRentalSWD.BusinessObjects
{
    public class ContactPoint
    {
        public int Id { get; set; }

        public string Contact {  get; set; }

        public CourtGroup CourtGroup { get; set; }
    }
}
