using SWD.BBMS.Repositories;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IServiceService
    {
        Task<PagedList<ServiceModel>> GetServices(int id, int pageNumber, int pageSize);

        Task<ServiceModel> GetServiceById(int id);

        Task<bool> SaveService(ServiceModel serviceModel);

        Task<bool> UpdateService(int id, Dictionary<string, object> serviceModel);

        Task<bool> DeleteService(int id);
    }
}
