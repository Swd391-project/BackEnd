using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class UserUpdateDictionary : Dictionary<string, object>
    {
        [JsonPropertyName("full-name")]
        public string FullName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone-number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
