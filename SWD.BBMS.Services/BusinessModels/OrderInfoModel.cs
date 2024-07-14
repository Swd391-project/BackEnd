using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class OrderInfoModel
    {
        public string OrderId { get; set; }
        public string OrderInfo { get; set; }
        public double Amount { get; set; }
    }
}
