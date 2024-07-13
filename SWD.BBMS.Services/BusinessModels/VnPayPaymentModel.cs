﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class VnPayPaymentModel
    {
        public string Description { get; set; }
        public string TransactionId { get; set; }
        public string PaymentMethodName { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }

        public double Amount { get; set; }

        public DateTime PayDate { get; set; }
    }
}
