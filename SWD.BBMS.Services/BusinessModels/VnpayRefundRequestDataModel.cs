using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class VnpayRefundRequestDataModel
    {
        [JsonProperty("vnp_RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("vnp_Version")]
        public string Version { get; set; }

        [JsonProperty("vnp_Command")]
        public string Command { get; set; }

        [JsonProperty("vnp_TmnCode")]
        public string TmnCode { get; set; }

        [JsonProperty("vnp_TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("vnp_TxnRef")]
        public string TxnRef { get; set; }

        [JsonProperty("vnp_Amount")]
        public string Amount { get; set; }

        [JsonProperty("vnp_OrderInfo")]
        public string OrderInfo { get; set; }

        [JsonProperty("vnp_TransactionNo")]
        public string TransactionNo { get; set; }

        [JsonProperty("vnp_TransactionDate")]
        public string TransactionDate { get; set; }

        [JsonProperty("vnp_CreateBy")]
        public string CreateBy { get; set; }

        [JsonProperty("vnp_CreateDate")]
        public string CreateDate { get; set; }

        [JsonProperty("vnp_IpAddr")]
        public string IpAddr { get; set; }

        [JsonProperty("vnp_SecureHash")]
        public string SecureHash { get; set; }
    }
}
