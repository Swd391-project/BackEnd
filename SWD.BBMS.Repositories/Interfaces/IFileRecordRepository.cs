using SWD.BBMS.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Interfaces
{
    public interface IFileRecordRepository
    {
        Task<bool> SaveFileRecord(FileRecord file);

        Task<FileRecord?> FindFileRecord(int id);

        Task<FileRecord> GetLastFileRecord();

        Task<bool> DeleteFileRecord(int id);
    }
}
