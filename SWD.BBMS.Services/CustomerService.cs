using AutoMapper;
using SWD.BBMS.Repositories;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository customerRepository;

        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public async Task<CustomerModel?> GetCustomerById(int id)
        {
            try
            {
                var customer = await customerRepository.GetCustomerById(id);
                var customerModel = mapper.Map<CustomerModel>(customer);
                return customerModel;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PagedList<CustomerModel>> GetCustomers(int pageNumber, int pageSize)
        {
            try
            {
                var customers = await customerRepository.GetCustomers(pageNumber, pageSize);
                var customerModels = mapper.Map<List<CustomerModel>>(customers);
                return new PagedList<CustomerModel>(customerModels, customers.TotalCount, customers.CurrentPage, customers.PageSize);
            }
            catch
            {
                throw;
            }
        }
    }
}
