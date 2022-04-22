using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_single.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public int Population { get; set; }
    }
}
