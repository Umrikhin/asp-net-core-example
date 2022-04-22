using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace table_group.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Login")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "Please enter Date Login")]
        public DateTime DateLogin { get; set; }

        [Required(ErrorMessage = "Please enter Date Exit")]
        public DateTime DateExit { get; set; }

        [Required(ErrorMessage = "Please enter Office")]
        public int idOffice { get; set; }
    }
    
}
