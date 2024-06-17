using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace SWD.BBMS.API.ViewModels.RequestModels
{
    public class OwnerParameters : IQueryModel
    {
        const int maxPageSize = 50;

        [FromQuery(Name = "page-number")]
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        [FromQuery(Name = "page-size")]
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize ? maxPageSize : value);
            }
        }
    }
}
