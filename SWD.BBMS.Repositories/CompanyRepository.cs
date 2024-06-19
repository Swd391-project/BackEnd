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
    public class CompanyRepository : ICompanyRepository
    {
        public async Task<List<Company>> GetCompanies()
        {
            var companies = new List<Company>(); 
            try
            {
                using var dbContext = new BBMSDbContext();
                companies = await dbContext.Companies.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return companies;
        }
    }
}
