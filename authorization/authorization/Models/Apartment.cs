using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authorization.Models
{
    public class Apartment
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Please enter Number Of Rooms")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Please enter Space")]
        [Range(typeof(double), "10", "100")]
        public double Space { get; set; }

        [Required(ErrorMessage = "Please enter Level")]
        [Range(typeof(int), "1", "30")]
        public int Level { get; set; }

        [Required(ErrorMessage = "Please enter Number Of Storeys")]
        [Range(typeof(int), "1", "30")]
        public int NumberOfStoreys { get; set; }

        [Required(ErrorMessage = "Please enter Adres")]
        [StringLength(50, ErrorMessage = "Please enter no more than 50 characters.")]
        public string Adres{ get; set; }

        [Required(ErrorMessage = "Please enter Number Of Price")]
        [Range(typeof(decimal), "500000", "10000000")]
        public decimal Price { get; set; }
       
    }
}
