using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWD.BBMS.Services.BusinessModels
{
    public class ServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public string Unit { get; set; }

        public CourtGroupModel CourtGroup { get; set; }
    }
}
