using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace file_hosting.Models
{
    //File upload class
    public class FileUpload
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public long Size { get; set; }

        [Required]
        public DateTime DateLoad { get; set; }
    }

    //File download class
    public class FileForDownload
    {
        public string Name { get; set; }
    }

}
