namespace BadmintonRentalSWD.BusinessObjects
{
    public class CourtGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public ICollection<Court>? Courts { get; set; }

        public ICollection<CourtSlot>? CourtSlots { get; set; }

        public Company Company { get; set; }    
    }
}
