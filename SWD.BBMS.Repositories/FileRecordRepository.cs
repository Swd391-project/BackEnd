using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class FileRecordRepository : IFileRecordRepository
    {
        public async Task<bool> DeleteFileRecord(int id)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                var fileRecord = await dbContext.FileRecords.FindAsync(id);
                if (fileRecord == null)
                {
                    throw new Exception($"File record with id {id} not found in delete file.");
                }
                dbContext.FileRecords.Remove(fileRecord);
                await dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<FileRecord?> FindFileRecord(int id)
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                return await dbContext.FileRecords.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FileRecord> GetLastFileRecord()
        {
            try
            {
                using var dbContext = new BBMSDbContext();
                if (dbContext.FileRecords.IsNullOrEmpty())
                {
                    return null;
                }
                return await dbContext.FileRecords.OrderByDescending(fc => fc.Id).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveFileRecord(FileRecord file)
        {
            var result = false;
            try
            {
                using var dbContext = new BBMSDbContext();
                await dbContext.FileRecords.AddAsync(file);
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
