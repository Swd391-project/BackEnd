using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> FindCustomer(int customerId);

        Task<Customer?> GetCustomerByPhoneNumber(string phoneNumber);
    }
}
