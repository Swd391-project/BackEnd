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
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer?> FindCustomer(int customerId)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Customers.FindAsync(customerId);
        }

        public async Task<Customer?> GetCustomerByPhoneNumber(string phoneNumber)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Customers.FirstOrDefaultAsync(c => c.PhoneNumber.Equals(phoneNumber));
        }
    }
}
