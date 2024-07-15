using Microsoft.AspNetCore.Http;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IVnPayService
    {

        string CreatePaymentUrl(PaymentModel paymentModel, HttpContext context, string currentPath);

        string CreatePaymentUrlForBooking(List<BookingModel> bookingModels, HttpContext context, string currentPath);

        VnPayPaymentModel PaymentExecute(IQueryCollection collections);

        Task<VnPayPaymentModel> BookingPaymentExecute(IQueryCollection collections);
    }
}
