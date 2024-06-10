using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class ContactPointModel
    {
        public int Id { get; set; }

        public string Contact { get; set; }

        public CourtGroupModel CourtGroup { get; set; }
    }
}
