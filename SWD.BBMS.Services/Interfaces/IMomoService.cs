using Microsoft.AspNetCore.Http;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model, string currentPath);
        Task<MomoExecuteResponseModel> PaymentExecuteAsync(IQueryCollection collection);

        Task<MomoRefundResponseModel> CreateRequestDataForMomoRefund(PaymentModel paymentModel);
    }
}
