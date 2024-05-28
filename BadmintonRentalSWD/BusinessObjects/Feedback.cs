namespace BadmintonRentalSWD.BusinessObjects
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public float Rate {  get; set; }

        public CourtGroup CourtGroup { get; set; }

        public User User { get; set; }
    }
}
