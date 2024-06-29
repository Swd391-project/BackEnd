using Microsoft.AspNetCore.Http;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IFileRecordService
    {
        Task<FileRecordModel> SaveFileRecord(IFormFile file, string downloadUrl);

        Task<FileRecordModel?> FindFileRecord(int id);

        Task<bool> DeleteFileRecord(int id);
    }
}
