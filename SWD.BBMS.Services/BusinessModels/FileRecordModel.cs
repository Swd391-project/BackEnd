using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.BusinessModels
{
    public class FileRecordModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}
