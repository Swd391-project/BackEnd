using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Parameters
{
    public class CourtGroupParameters : QueryStringParameters
    {
        [FromQuery(Name = "name")]
        public string? Name { get; set; }

        [FromQuery(Name = "rate")]
        public float Rate { get; set; } = 0;

        [FromQuery(Name = "search-name")]
        public string? SearchName { get; set; }
    }
}
