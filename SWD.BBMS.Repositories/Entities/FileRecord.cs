using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.BBMS.Repositories.Entities
{
    [Table("FileRecord")]
    public class FileRecord
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}
