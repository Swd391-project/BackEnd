using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string Id { get; set; }

        public string FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        //public string? Password { get; set; }

        public string Role { get; set; }

        public string? Image {  get; set; }

        public UserStatus Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public Company? Company { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
