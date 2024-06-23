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

        public async Task<Customer?> GetCustomerById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Customers.Include(c => c.Bookings).Include(c => c.FlexibleBookings).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetCustomerByPhoneNumber(string phoneNumber)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Customers.FirstOrDefaultAsync(c => c.PhoneNumber.Equals(phoneNumber));
        }

        public async Task<PagedList<Customer>> GetCustomers(int pageNumber, int pageSize)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var customers = await PagedList<Customer>.ToPagedList(dbContext.Customers, pageNumber, pageSize);
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
