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
    public class ServiceRepository : IServiceRepository
    {
        public Task<bool> DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Service?> GetServiceById(int id)
        {
            using var dbContext = new BBMSDbContext();
            return await dbContext.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedList<Service>> GetServices(int id, int pageNumber, int pageSize)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                var services = await PagedList<Service>
                    .ToPagedList(dbContext.Services.Where(s => s.CourtGroupId == id), pageNumber, pageSize);
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveService(Service service)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                await dbContext.Services.AddAsync(service);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateService(Service service)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                dbContext.Attach(service).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
