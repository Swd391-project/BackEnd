using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<PagedList<Service>> GetServices(int id, int pageNumber, int pageSize);

        Task<Service?> GetServiceById(int id);

        Task<bool> SaveService(Service service);

        Task<bool> UpdateService(Service service);

        Task<bool> DeleteService(int id);
    }
}
