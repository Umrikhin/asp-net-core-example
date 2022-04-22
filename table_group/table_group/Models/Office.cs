using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace table_group.Models
{
    public class Office
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Office Name")]
        public string OfficeName { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }
    }
}
