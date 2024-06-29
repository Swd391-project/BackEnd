using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Repositories.Interfaces;
using SWD.BBMS.Services.BusinessModels;
using SWD.BBMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services
{
    public class FileRecordService : IFileRecordService
    {
        private readonly IFileRecordRepository fileRecordRepository;

        private readonly IMapper mapper;

        public FileRecordService(IFileRecordRepository fileRecordRepository, IMapper mapper)
        {
            this.fileRecordRepository = fileRecordRepository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteFileRecord(int id)
        {
            try
            {
                return await fileRecordRepository.DeleteFileRecord(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<FileRecordModel?> FindFileRecord(int id)
        {
            try
            {
                var fileRecord = await fileRecordRepository.FindFileRecord(id);
                var model = mapper.Map<FileRecordModel>(fileRecord);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<FileRecordModel> SaveFileRecord(IFormFile file, string downloadUrl)
        {
            try
            {
                // Read the file into byte array
                byte[] fileData;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                // Create new file record
                var fileRecord = new FileRecord
                {
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    Data = fileData
                };

                // Find id for new file record and download url
                /*
                var lastFileRecord = await fileRecordRepository.GetLastFileRecord();
                if (lastFileRecord == null)
                {
                    fileRecord.Url = downloadUrl + "/1";
                }
                else
                {
                    var lastFileRecordModel = mapper.Map<FileRecordModel>(lastFileRecord);
                    fileRecord.Url = downloadUrl + "/" + ++lastFileRecordModel.Id;
                }
                */

                // Save new file record
                var result = await fileRecordRepository.SaveFileRecord(fileRecord);
                if (!result)
                {
                    throw new Exception("Something went wrong when saving new file record.");
                }

                // Get new file record to response 
                var newFileRecord = await fileRecordRepository.GetLastFileRecord();
                var model = mapper.Map<FileRecordModel>(newFileRecord);
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}
