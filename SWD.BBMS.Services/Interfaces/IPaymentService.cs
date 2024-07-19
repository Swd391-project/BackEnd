using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentModel> CreateCashPaymentForBooking(List<BookingModel> bookingModels, double totalPrice);

        Task<PaymentModel> CreateBankingPaymentForBooking(List<BookingModel> bookingModels, string bankCode, string transactionId);

        Task<PaymentModel?> GetPaymentByBookingId(int bookingId);
    }
}
