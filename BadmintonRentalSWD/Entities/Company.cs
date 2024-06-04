using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BadmintonRentalSWD.Entities
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Balance { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public ICollection<CourtGroup>? CourtGroups { get; set; }

        public ICollection<User>? Users { get; set; }

        public ICollection<Withdraw>? Withdraws { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }
}
