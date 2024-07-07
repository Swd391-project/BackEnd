using Microsoft.EntityFrameworkCore;
using SWD.BBMS.Repositories.Data;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        public async Task<PaymentMethod?> GetPaymentMethodByName(string name)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.PaymentMethods.FirstOrDefaultAsync(pm => pm.MethodName.ToLower().Equals(name.Trim().ToLower()));
        }
    }
}
