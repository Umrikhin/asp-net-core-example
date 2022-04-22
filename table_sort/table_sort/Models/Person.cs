using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace table_sort.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter Driving Experience")]
        public int DrivingExperience { get; set; }
    }
    
}
